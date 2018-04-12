using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;
using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
	public static partial class _
	{
		public static bool Same(Expression e1, Expression e2)
		{
			return (bool)(e1.Perform(new Same(e2)) as Logical);
		}
		public static Expression Calculate(Expression e)
		{
			return e.Perform(new Calculate());
		}
		public static Expression Simplify(Expression e)
		{
			return e.Canonical().Perform(new Simplify()).Canonical();
		}
		public static Expression Derivative(Expression e, Symbol var)
		{
			return e.Perform(new Derivative(var)).Simplify();
		}
		public static Expression Derivative(Expression e)
		{
			var syms = e.Symbols();
			if (syms.Count() == 0)
			{
				return 0;
			}
			return Derivative(e, syms.Single());
		}
		public static Expression D(Expression e, Symbol var)
		{
			return Derivative(e, var);
		}
		public static Expression D(Expression e)
		{
			return Derivative(e);
		}
		public static bool Equal(Expression e1, Expression e2)
		{
			return _.Same(e1.Simplify(), e2.Simplify());
		}
		public static Expression Replace(Expression e, params Rule[] rules)
		{
			return e.Simplify().Perform(new Replace(rules)).Simplify();
		}
		public static Expression Integer(Expression e)
		{
			return new TypePattern(e, typeof(Integer));
		}
		public static Expression any<T>(Expression e)
		{
			return new TypePattern(e, typeof(T));
		}
	}
}
