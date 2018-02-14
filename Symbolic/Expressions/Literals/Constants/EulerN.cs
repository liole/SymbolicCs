using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Literals.Constants
{
	// public class E : Real, IConstant
	public class EulerN : Real, IConstant
	{
		public string Name => "e";

		public EulerN():
			base(Math.E)
		{
		}
	}
}
