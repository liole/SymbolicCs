using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions
{
	public abstract class BinaryOperator : Expression
	{
		public static BracketsType BracketsType = BracketsType.Round;
		public abstract string Sign { get; }
		public abstract int Priority { get; }

		public Expression Left { get; set; }
		public Expression Right { get; set; }

		public BinaryOperator(Expression left, Expression right)
		{
			Left = left;
			Right = right;
		}

		public string ToString(bool brackets)
		{
			var sb = new StringBuilder();
			if (brackets)
			{
				sb.Append(BracketsType.Open());
			}
			if (Left is BinaryOperator)
			{
				var leftBO = Left as BinaryOperator;
				sb.Append(leftBO.ToString(Priority > leftBO.Priority));
			} else
			{
				sb.Append(Left.ToString());
			}
			sb.Append(Sign);
			if (Right is BinaryOperator)
			{
				var rightBO = Right as BinaryOperator;
				sb.Append(rightBO.ToString(Priority > rightBO.Priority));
			}
			else
			{
				sb.Append(Right.ToString());
			}
			if (brackets)
			{
				sb.Append(BracketsType.Close());
			}
			return sb.ToString();
		}
		public override string ToString()
		{
			return ToString(false);
		}
	}
}
