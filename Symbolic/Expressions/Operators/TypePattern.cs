using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Operators
{
	public class TypePattern: Pattern
	{
		public override string Sign => $"~<{Type.Name}>";
		public override int Priority => 0;

		public Type Type { get; set; }

		public TypePattern(Expression arg) :
			base(arg)
		{
		}
		public TypePattern(Expression arg, Type type) :
			base(arg)
		{
			Type = type;
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
	}
}
