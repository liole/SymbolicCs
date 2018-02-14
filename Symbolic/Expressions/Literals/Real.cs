using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Literals
{
	public class Real: Literal
	{
		public virtual double Value { get; protected set; }

		public Real(double val)
		{
			Value = val;
		}

		public static explicit operator double(Real src)
		{
			return src.Value;
		}

		public static implicit operator Real(double src)
		{
			// this should not work but it does!
			switch (src)
			{
				case 0.0:
					return _.Zero as Real;
				case 1.0:
					return _.One as Real;
				case Math.E:
					return _.E as Real;
				case Math.PI:
					return _.Pi as Real;
				default:
					return new Real(src);
			}
		}

		public override string ToString()
		{
			if (this is IConstant)
			{
				return (this as IConstant).Name;
			}
			return Value.ToString();
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
	}
}
