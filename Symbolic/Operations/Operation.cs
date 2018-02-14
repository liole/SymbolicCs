using Symbolic.Expressions;
using Symbolic.Expressions.Functions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Operations
{
	public class Operation
	{
		public virtual Expression On(Expression e)
		{
			return e;
		}
		public virtual Expression On(Symbol e) => On(e as Expression);
		public virtual Expression On(Literal e) => On(e as Expression);
		public virtual Expression On(Integer e) => On(e as Literal);
		public virtual Expression On(Real e) => On(e as Literal);
		public virtual Expression On(Logical e) => On(e as Literal);
		public virtual Expression On(Function e) => On(e as Expression);
		public virtual Expression On (Sin e) => On(e as Function);
		public virtual Expression On(Cos e) => On(e as Function);
		public virtual Expression On(Sqrt e) => On(e as Function);
		public virtual Expression On(Pow e) => On(e as Function);
		public virtual Expression On(Exp e) => On(e as Pow);
		public virtual Expression On(Log e) => On(e as Function);
		public virtual Expression On(Ln e) => On(e as Log);
		public virtual Expression On(Lg e) => On(e as Log);
		public virtual Expression On(BinaryOperator e) => On(e as Function);
		public virtual Expression On(Plus e) => On(e as BinaryOperator);
		public virtual Expression On(Minus e) => On(e as BinaryOperator);
		public virtual Expression On(Times e) => On(e as BinaryOperator);
		public virtual Expression On(Divide e) => On(e as BinaryOperator);
	}
}
