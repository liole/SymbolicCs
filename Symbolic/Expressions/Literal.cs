using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions
{
	public abstract class Literal: Expression
	{
		internal abstract int CompareTo(Literal e);
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
	}
}
