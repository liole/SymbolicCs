﻿using Symbolic.Expressions;
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
	}
}
