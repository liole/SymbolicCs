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
		public static Logical Same(Expression e1, Expression e2)
		{
			return e1.Perform(new Same(e2)) as Logical;
		}
	}
}
