using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions
{
	public abstract class BinaryOperator : Function
	{
		public static new BracketsType BracketsType = BracketsType.Round;
		public abstract string Sign { get; }
		public abstract int Priority { get; }
		public override string Name => Sign;

		public Expression Left
		{
			get => Arguments[0];
			set => Arguments[0] = value;
		}
		public Expression Right
		{
			get => Arguments[1];
			set => Arguments[1] = value;
		}

		public BinaryOperator(Expression left, Expression right):
			base(left, right)
		{
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
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
