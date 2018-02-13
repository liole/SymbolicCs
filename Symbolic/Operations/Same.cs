using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;

namespace Symbolic.Operations
{
	class Same: Operation
	{
		public Expression Source { get; set; }

		public Same(Expression src)
		{
			Source = src;
		}

		public override Expression On(Symbol e)
		{
			return Source is Symbol &&
				(Source as Symbol).Name == e.Name;
		}
		public override Expression On(Integer e)
		{
			return Source is Integer &&
				(Source as Integer).Value == e.Value;
		}
		public override Expression On(Logical e)
		{
			return Source is Logical &&
				(Source as Logical).Value == e.Value;
		}
		public override Expression On(Function e)
		{
			if (Source is Function)
			{
				var sbo = Source as Function;
				return Source.GetType() == e.GetType() &&
					sbo.Arguments.Length == e.Arguments.Length &&
					Enumerable.Zip(sbo.Arguments, e.Arguments,
						(sa, ea) => _.Same(ea, sa))
						.All(same => same);
			}
			return false;
		}
	}
}
