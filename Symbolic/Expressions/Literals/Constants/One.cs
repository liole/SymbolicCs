using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Literals.Constants
{
	public class One : Integer, IConstant
	{
		public string Name => "1";

		public One():
			base(1)
		{
		}
	}
}
