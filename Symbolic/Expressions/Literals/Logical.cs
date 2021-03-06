﻿using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Literals
{
	public class Logical: Literal
	{
		public bool Value { get; set; }

		public Logical(bool val)
		{
			Value = val;
		}
		internal override int CompareTo(Literal e)
		{
			if (e is Logical)
			{
				return Value.CompareTo((e as Logical).Value);
			}
			else
			{
				// Real
				return -1;
			}
		}

		public static explicit operator bool(Logical src)
		{
			return src.Value;
		}

		public static implicit operator Logical(bool src)
		{
			return new Logical(src);
		}

		public override string ToString()
		{
			return Value.ToString();
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
	}
}
