using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Operators
{
	public class Pattern: UnaryOperator
	{
		public override string Sign => "~";
		public override int Priority => 0;

		public Pattern(Expression arg) :
			base(arg)
		{
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
	}
}
