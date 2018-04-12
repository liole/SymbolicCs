using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;

namespace Symbolic.Operations
{
	class Similar: Same
	{
		public List<Rule> Rules { get; set; }

		public Similar(Expression src):
			base(src)
		{
			Rules = new List<Rule>();
		}

		public override Expression On(Pattern e)
		{
			Rules.Add(new Rule(e.Argument, Source));
			return true;
		}
		public override Expression On(TypePattern e)
		{
			if (e.Type.IsInstanceOfType(Source))
			{
				Rules.Add(new Rule(e.Argument, Source));
				return true;
			}
			return base.On(e);
		}

		//public override Expression On(BinaryOperator e)
		//{
		//	return (bool)(On(e as Function) as Logical) || (
		//		Source.GetType() == e.GetType() && e.Associative && (
		//		e.Left.GetType() == e.GetType() && (bool)(On(Activator.CreateInstance(
		//			e.GetType(),
		//			(e.Left as BinaryOperator).Left,
		//			Activator.CreateInstance(
		//				e.GetType(),
		//				(e.Left as BinaryOperator).Right,
		//				e.Right
		//			) as Expression) as Expression) as Logical) ||
				
		//		);
		//}

		public override Expression On(Function e)
		{
			if (Source is Function)
			{
				var sbo = Source as Function;
				return Source.GetType() == e.GetType() &&
					sbo.Arguments.Length == e.Arguments.Length &&
					Enumerable.Zip(sbo.Arguments, e.Arguments,
						(sa, ea) =>
						{
							Rule[] newRules;
							var res = ea.Match(sa, out newRules);
							foreach(var newRule in newRules)
							{
								if (Rules.Any(r => _.Equals(r.Left, newRule.Left)))
								{
									return false;
								}
							}
							Rules.AddRange(newRules);
							return res;
						})
						.All(same => same);
			}
			return false;
		}
		public override Expression On(SymbolFunction e)
		{
			return (bool)(On(e as Function) as Logical) && 
				e.Derivatives
					.Zip((Source as SymbolFunction).Derivatives, (ed, sd) => ed <= sd)
					.All(same => same);
		}
	}
}
