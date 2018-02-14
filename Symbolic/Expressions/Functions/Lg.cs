using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Functions
{
	public class Lg : Log
	{
		public override string Name => "lg";

		public Lg(Expression arg):
			base(arg, 10)
		{
		}
		public Lg(Expression arg, Expression ignoring) : // for operation compatibility
			this(arg)
		{
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
		public override string ToString()
		{
			var args = Arguments;
			Arguments = new[] { Arguments[0] };
			var res = base.ToString();
			Arguments = args;
			return res;
		}
	}
}
