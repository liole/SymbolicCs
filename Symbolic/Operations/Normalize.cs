using Symbolic.Expressions;
using Symbolic.Expressions.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Operations
{
	class Normalize : Clone
	{
		public override Expression On(Times e)
		{
			var left = e.Left;
			var right = e.Right.Normalize();
			if (right is Times || right is Divide)
			{
				var binOp = right as BinaryOperator;
				left = left * binOp.Left;
				right = binOp.Right;
				if (binOp is Divide)
				{
					return On(left / right as Divide, false);
				}
			}
			left = left.Normalize();
			if (left is Divide)
			{
				var binOp = left as BinaryOperator;
				left = binOp.Left * right;
				right = binOp.Right;
				return On(left / right as Divide, false);
			}
			return left * right;
		}
		public override Expression On(Divide e)
		{
			return On(e, true);
		}
		public Expression On(Divide e, bool full)
		{
			var left = e.Left;
			var right = e.Right;
			if (full)
			{
				right = right.Normalize();
			}
			if (right is Divide)
			{
				var binOp = right as BinaryOperator;
				left = left * binOp.Right;
				right = binOp.Left;
			}
			left = left.Normalize();
			if (left is Divide)
			{
				var binOp = left as BinaryOperator;
				left = binOp.Left;
				right = (binOp.Right * right).Normalize();
			}
			return left / right;
		}
	}
}
