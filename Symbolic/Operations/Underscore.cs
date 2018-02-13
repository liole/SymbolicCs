using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
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
		public static Expression Clone(Expression e)
		{
			return e.Perform(new Clone());
		}
		public static Expression Calculate(Expression e)
		{
			return e.Perform(new Calculate());
		}
		public static Expression Simplify(Expression e)
		{
			return e.Perform(new Simplify());
		}
	}
}
