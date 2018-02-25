using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbolic.Expressions;
using Symbolic.Expressions.Functions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;

namespace Symbolic.Operations
{
	class Replace: Operation
	{
		public Rule[] Rules { get; set; }

		public Replace(params Rule[] rules)
		{
			Rules = rules;
		}

		public override Expression On(Expression e)
		{
			foreach (var rule in Rules)
			{
				Rule[] patternRules;
				if (rule.Left.Match(e, out patternRules))
				{
					return rule.Right.Replace(patternRules);
				}
			}
			if (e is Function)
			{
				return e;
			}
			else
			{
				return e.Clone();
			}
		}
		public override Expression On(Pattern e)
		{
			return e.Argument.Replace(Rules);
		}
		public override Expression On(Function e)
		{
			var res = On(e as Expression);
			if (ReferenceEquals(res, e))
			{
				return Clone.On(e, new Replace(Rules));
			}
			return res;
		}
		List<Symbol> tmpSymbols = new List<Symbol>();
		Symbol tmpSymbol()
		{
			var rand = new Random();
			var name = rand.NextDouble().ToString();
			var tmp = new Symbol(name);
			tmpSymbols.Add(tmp);
			return tmp;
		}
		bool isTemp(Symbol sym)
		{
			return tmpSymbols.Select(s => s.Name).Contains(sym.Name);
		}
		public override Expression On(SymbolFunction e)
		{
			foreach (var rule in Rules)
			{
				Rule[] patternRules;
				if (rule.Left.Match(e, out patternRules))
				{
					var left = rule.Left as SymbolFunction;
					var tmpRules = patternRules
						.Select(r => new Rule(r.Left, tmpSymbol()))
						.ToArray();
					var invTmpRules = patternRules
						.Zip(tmpRules, (pr, tr) => new Rule(tr.Right, pr.Right))
						.ToArray();
					var res = rule.Right.Replace(tmpRules);
					var f = left.Replace(tmpRules) as SymbolFunction;
					for (int i = 0; i < e.Derivatives.Length; ++i)
					{
						var vars = f.Symbols().Where(s => isTemp(s));
						if (e.Derivatives[i] != left.Derivatives[i])
						{
							if (vars.Count() == 0 || vars.Count() > 1)
							{
								return Clone.On(e, new Replace(Rules));
							}
							for (int d = left.Derivatives[i]; d < e.Derivatives[i]; ++d)
							{
								res = _.D(res, vars.Single()) / _.D(f.Arguments[i], vars.Single());
							}
						}
					}
					return res.Replace(invTmpRules);
				}
			}
			return Clone.On(e, new Replace(Rules));
		}
	}
}
