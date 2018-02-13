using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Functions
{
	public class Sin : Function
	{
		public override string Name => "sin";

		public Sin(Expression arg):
			base(arg)
		{
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
	}
}
