using Symbolic.Expressions;
using Symbolic.Expressions.Functions;
using Symbolic.Expressions.Literals.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
	public static partial class _
	{
		public static Expression Zero = new Zero();
		public static Expression One = new One();
		public static Expression E = new EulerN();
		public static Expression Pi = new Pi();

		public static Expression Sin(Expression arg) => new Sin(arg);
		public static Expression Cos(Expression arg) => new Cos(arg);
		public static Expression Sqrt(Expression arg) => new Sqrt(arg);
		public static Expression Pow(Expression arg, Expression exp) => new Pow(arg, exp);
		public static Expression Log(Expression arg, Expression exp) => new Log(arg, exp);
		public static Expression Exp(Expression arg) => new Exp(arg);
		public static Expression Ln(Expression arg) => new Ln(arg);
		public static Expression Lg(Expression arg) => new Lg(arg);
	}
}
