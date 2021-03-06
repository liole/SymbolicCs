﻿using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Literals
{
	public class Integer: Real
	{
		//TODO: store only one Value (object?)
		public new int Value { get; protected set; }

		public Integer(int val):
			base(val)
		{
			Value = val;
		}

		public static explicit operator int(Integer src)
		{
			return src.Value;
		}

		public static implicit operator Integer(int src)
		{
			switch (src)
			{
				case 0:
					return _.Zero as Integer;
				case 1:
					return _.One as Integer;
				default:
					return new Integer(src);
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
