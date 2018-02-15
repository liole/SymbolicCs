using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions
{
	public abstract class UnaryOperator : Function
	{
		public static new BracketsType BracketsType = BracketsType.Round;
		public abstract string Sign { get; }
		public abstract int Priority { get; }
		public override string Name => Sign;

		public UnaryOperator(Expression arg):
			base(arg)
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

			sb.Append(Sign);
			if (Argument is BinaryOperator)
			{
				var bo = Argument as BinaryOperator;
				sb.Append(bo.ToString(Priority >= bo.Priority));
			} else if (Argument is UnaryOperator)
			{
				var uo = Argument as UnaryOperator;
				sb.Append(uo.ToString(Priority >= uo.Priority));
			}
			else
			{
				sb.Append(Argument.ToString());
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
