using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Operators
{
	public class Times : BinaryOperator
	{
		public override string Sign => "*";
		public override int Priority => 3;

		public Times(Expression left, Expression right) :
			base(left, right)
		{
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
	}
}
