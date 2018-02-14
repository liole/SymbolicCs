using Symbolic.Expressions;
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
			return _.Clone(e);
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
	}
}
