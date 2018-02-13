﻿using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;
using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions
{
    public abstract class Expression
    {
		public virtual Expression Perform(Operation operation)
		{
			return operation.On(this);
		}

		public static implicit operator Expression(int src) => (Integer)src;
		public static implicit operator Expression(bool src) => (Logical)src;

		public static Expression operator +(Expression left, Expression right)
		{
			return new Plus(left, right);
		}
		public static Expression operator -(Expression left, Expression right)
		{
			return new Minus(left, right);
		}
		public static Expression operator *(Expression left, Expression right)
		{
			return new Times(left, right);
		}
		public static Expression operator /(Expression left, Expression right)
		{
			return new Divide(left, right);
		}
	}
}