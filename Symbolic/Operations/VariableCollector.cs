using Symbolic.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Operations
{
	class VariableCollector: Operation
	{
		public HashSet<string> Variables { get; set; }
		public IEnumerable<Symbol> Symbols => Variables.Select(v => new Symbol(v));

		public VariableCollector()
		{
			Variables = new HashSet<string>();
		}

		public override Expression On(Symbol e)
		{
			Variables.Add(e.Name);
			return base.On(e);
		}
		public override Expression On(Function e)
		{
			foreach(var arg in e.Arguments)
			{
				arg.Perform(this);
			}
			return base.On(e);
		}
	}
}
