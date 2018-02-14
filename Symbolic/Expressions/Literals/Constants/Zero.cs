using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Literals.Constants
{
	public class Zero : Integer, IConstant
	{
		public string Name => "0";

		public Zero():
			base(0)
		{
		}
	}
}
