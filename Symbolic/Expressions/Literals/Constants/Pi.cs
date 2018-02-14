using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Literals.Constants
{
	public class Pi : Real, IConstant
	{
		public string Name => "pi"; // π ?

		public Pi():
			base(Math.PI)
		{
		}
	}
}
