using Symbolic.Expressions;
using Symbolic.Expressions.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
	public static partial class _
	{
		public static Expression Sin(Expression arg) => new Sin(arg);
		public static Expression Cos(Expression arg) => new Cos(arg);
		public static Expression Sqrt(Expression arg) => new Sqrt(arg);
	}
}
