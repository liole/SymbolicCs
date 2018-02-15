using Symbolic.Expressions;
using Symbolic.Expressions.Functions;
using Symbolic.Expressions.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Operations
{
	class Derivative: Operation
	{
		public Symbol Variable { get; set; }
		private Symbol x => Variable;

		public Derivative(Symbol variable)
		{
			Variable = variable;
		}

		public override Expression On(Symbol e)
		{
			return _.Same(e, x) ? 1 : 0;
		}
		public override Expression On(Literal e)
		{
			return 0;
		}
		public override Expression On(SymbolFunction e)
		{
			return e.Arguments
				.Select((arg, i) => e.D(i) * _.D(arg, x))
				.Aggregate((a, b) => a + b);
		}
		public override Expression On(Plus e)
		{
			return _.D(e.Left, x) + _.D(e.Right, x);
		}
		public override Expression On(Minus e)
		{
			return _.D(e.Left, x) - _.D(e.Right, x);
		}
		public override Expression On(Times e)
		{
			return _.D(e.Left, x)*e.Right + e.Left*_.D(e.Right,x);
		}
		public override Expression On(Divide e)
		{
			return (_.D(e.Left, x)*e.Right - e.Left*_.D(e.Right, x))/_.Pow(e.Right, 2);
		}
		public override Expression On(Sin e)
		{
			return _.Cos(e.Argument) * _.D(e.Argument, x);
		}
		public override Expression On(Cos e)
		{
			return -_.Sin(e.Argument) * _.D(e.Argument, x);
		}
		public override Expression On(Sqrt e)
		{
			return _.D(e.Argument, x) / (2*_.Sqrt(e.Argument));
		}
		public override Expression On(Exp e)
		{
			return e * _.D(e.Argument, x);
		}
		public override Expression On(Pow e)
		{
			if (e.Arguments[0] is Literal)
			{
				// temporary; simplify should take care of this ?
				return e * _.Ln(e.Arguments[0]) * _.D(e.Arguments[1], x);
			}
			else if (e.Arguments[1] is Literal)
			{
				// temporary; simplify should take care of this ?
				return e.Arguments[1] * _.Pow(e.Arguments[0], e.Arguments[1] - 1) *
					_.D(e.Arguments[0], x);
			}
			else
			{
				var f = e.Arguments[0];
				var g = e.Arguments[1];
				return _.Pow(f, g-1) * (_.D(f, x)*g + f*_.D(g, x)*_.Ln(f));
			}
		}
		public override Expression On(Ln e)
		{
			return _.D(e.Argument, x) / e.Argument;
		}
		public override Expression On(Log e)
		{
			if (e.Arguments[1] is Literal)
			{
				// temporary; simplify should take care of this
				return _.D(e.Arguments[0], x) / (e.Arguments[0] * _.Ln(e.Arguments[1]));
			}
			else
			{
				return _.D(_.Ln(e.Arguments[0]) / _.Ln(e.Arguments[1]), x);
			}
		}
	}
}
