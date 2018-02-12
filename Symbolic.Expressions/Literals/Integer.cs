using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Literals
{
	public class Integer: Literal
	{
		public int Value { get; protected set; }
		public Integer(int val)
		{
			Value = val;
		}

		public static explicit operator int(Integer src)
		{
			return src.Value;
		}

		public static implicit operator Integer(int src)
		{
			return new Integer(src);
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
