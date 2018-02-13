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
	class Clone: Operation
	{
		public override Expression On(Symbol e) => new Symbol(e.Name);
		public override Expression On(Integer e) => new Integer(e.Value);
		public override Expression On(Logical e) => new Logical(e.Value);
		public override Expression On(Function e)
		{
			return Activator.CreateInstance(
				e.GetType(), 
				e.Arguments.Select(a => a.Perform(
					Activator.CreateInstance(this.GetType()) as Operation)
				).ToArray()
			) as Function;
		}
	}
}
