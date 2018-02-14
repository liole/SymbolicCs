using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions
{
	public abstract class Function: Expression
	{
		public static BracketsType BracketsType = BracketsType.Square;
		public static SeparatorType SeparatorType = SeparatorType.Comma;
		public abstract string Name { get; }

		public Expression[] Arguments { get; protected set; }
		public virtual Expression Argument => Arguments[0];

		public Function (params Expression[] args)
		{
			Arguments = args;
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append(Name);
			sb.Append(BracketsType.Open());
			sb.Append(String.Join(SeparatorType.Value(), Arguments.AsEnumerable()));
			sb.Append(BracketsType.Close());
			return sb.ToString();
		}
	}
}
