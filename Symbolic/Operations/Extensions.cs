using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Operations
{
	public static class Extensions
	{
		public static IEnumerable<Symbol> Symbols(this Expression e)
		{
			var vars = new VariableCollector();
			e.Perform(vars);
			return vars.Symbols;
		}
		public static Expression Clone(this Expression e)
		{
			return e.Perform(new Clone());
		}
		public static Expression Calculate(this Expression e)
		{
			return _.Calculate(e);
		}
		public static Expression Simplify(this Expression e)
		{
			return _.Simplify(e);
		}
		public static Expression Prime(this Expression e, Symbol var)
		{
			return _.Derivative(e, var);
		}
		public static Expression Prime(this Expression e)
		{
			return _.Derivative(e);
		}
		public static Expression Normalize(this Expression e)
		{
			return e.Perform(new Normalize());
		}
		public static Expression Canonical(this Expression e)
		{
			return e.Normalize().Perform(new SortNodes());
		}
		public static bool Match(this Expression p, Expression e, out Rule[] rules)
		{
			var op = new Similar(e.Simplify());
			var res = p.Simplify().Perform(op);
			rules = op.Rules.ToArray();
			return (bool)(res as Logical);
		}
		public static bool Match(this Expression p, Expression e)
		{
			Rule[] rules;
			return p.Match(e, out rules);
		}
		public static Literal Coefficient(Expression e, out Expression body)
		{
			Rule[] rules;
			var c = new Symbol("c");
			var x = new Symbol("x");
			if ((_.any<Literal>(c)*(~x)).Match(e, out rules))
			{
				body = rules.Where(r => r.Left == x).Single().Right;
				return rules.Where(r => r.Left == c).Single().Right as Literal;
			}
			body = e.Clone();
			return _.One as Literal;
		}
		public static Literal Coefficient(Expression e)
		{
			Expression body;
			return Coefficient(e, out body);
		}
		public static Expression Replace(this Expression e, params Rule[] rules)
		{
			return _.Replace(e, rules);
		}
	}
}
