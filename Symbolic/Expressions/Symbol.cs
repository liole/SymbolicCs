using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions
{
	public class Symbol: Expression
	{
		public string Name { get; private set; }
		public Symbol(string name)
		{
			Name = name;
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
		public override string ToString()
		{
			return Name;
		}
	}
}
