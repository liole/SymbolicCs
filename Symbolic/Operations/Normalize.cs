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
		public override Expression On(Plus e)
		{
			var left = e.Left;
			var right = e.Right.Normalize();
			var plus = true;
			if (right is Plus || right is Minus)
			{
				plus = right is Plus;
				var binOp = right as BinaryOperator;
				left = left + binOp.Left;
				right = binOp.Right;
			}
			while (right is UnaryMinus)
			{
				plus = !plus;
				right = (right as UnaryMinus).Argument;
			}
			left = left.Normalize();
			if (plus)
			{
				return left + right;
			}
			else
			{
				return left - right;
			}
		}
		public override Expression On(Minus e)
		{
			var left = e.Left;
			var right = e.Right.Normalize();
			var minus = true;
			if (right is Plus || right is Minus)
			{
				minus = right is Plus;
				var binOp = right as BinaryOperator;
				left = left + binOp.Left;
				right = binOp.Right;
			}
			while (right is UnaryMinus)
			{
				minus = !minus;
				right = (right as UnaryMinus).Argument;
			}
			left = left.Normalize();
			if (minus)
			{
				return left - right;
			}
			else
			{
				return left + right;
			}
		}
	}
}
