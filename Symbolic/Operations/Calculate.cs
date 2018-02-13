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
	class Calculate: Clone
	{
		public override Expression On(Plus e)
		{
			var res = base.On(e) as Plus;
			if (res.Left is Integer && res.Right is Integer)
			{
				return new Integer((res.Left as Integer).Value + (res.Right as Integer).Value);
			}
			return res;
		}
		public override Expression On(Minus e)
		{
			var res = base.On(e) as Minus;
			if (res.Left is Integer && res.Right is Integer)
			{
				return new Integer((res.Left as Integer).Value - (res.Right as Integer).Value);
			}
			return res;
		}
		public override Expression On(Times e)
		{
			var res = base.On(e) as Times;
			if (res.Left is Integer && res.Right is Integer)
			{
				return new Integer((res.Left as Integer).Value * (res.Right as Integer).Value);
			}
			return res;
		}
		public override Expression On(Divide e)
		{
			var res = base.On(e) as Divide;
			if (res.Left is Integer && res.Right is Integer)
			{
				return new Integer((res.Left as Integer).Value / (res.Right as Integer).Value);
			}
			return res;
		}
	}
}
