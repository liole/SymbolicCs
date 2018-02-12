using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Functions
{
	public class Sqrt : Function
	{
		public override string Name => "sqrt";

		public Sqrt(Expression arg):
			base(arg)
		{
		}
	}
}
