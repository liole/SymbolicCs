using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Functions
{
	public class Exp : Pow
	{
		public override string Name => "exp";

		public Exp(Expression arg):
			base(Math.E, arg)
		{
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
		public override string ToString()
		{
			var args = Arguments;
			Arguments = new[] { Arguments[1] };
			var res = base.ToString();
			Arguments = args;
			return res;
		}
	}
}
