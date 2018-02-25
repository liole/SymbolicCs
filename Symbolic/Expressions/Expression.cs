using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Literals.Constants;
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

		public static implicit operator Expression(string src) => (Symbol)src;

		public static implicit operator Expression(int src) => (Integer)src;
		public static implicit operator Expression(double src) => (Real)src;
		public static implicit operator Expression(bool src) => (Logical)src;

		public static implicit operator int(Expression e)
		{
			var hash = e.GetHashCode();
			Rule.HashTable[hash] = e;
			return hash;
		}

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
		public static Expression operator -(Expression arg)
		{
			return new UnaryMinus(arg);
		}

		public static Expression operator ~(Expression arg)
		{
			return new Pattern(arg);
		}

		public static Rule operator >>(Expression left, int right)
		{
			return new Rule(left, right);
		}
	}
}
