using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbolic.Expressions;
using Symbolic.Expressions.Functions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;

namespace Symbolic.Operations
{
	class Calculate: Clone
	{
		private int pow(int a, int b)
		{
			var res = 1;
			for(var i = 0; i < b; ++i)
			{
				res *= a;
			}
			return res;
		}
		public override Expression On(Pow e)
		{
			var res = base.On(e) as Pow;
			if (res.Arguments[0] is Literal && res.Arguments[1] is Literal)
			{
				if (res.Arguments[0] is Integer && res.Arguments[1] is Integer &&
					(res.Arguments[1] as Integer).Value >= 0)
				{
					return pow(
						(res.Arguments[0] as Integer).Value, 
						(res.Arguments[1] as Integer).Value
					);
				}
				else
				{
					return Math.Pow(
						(res.Arguments[0] as Real).Value,
						(res.Arguments[1] as Real).Value
					);
				}
			}
			return res;
		}
		public override Expression On(Plus e)
		{
			var res = base.On(e) as Plus;
			if (res.Left is Literal && res.Right is Literal)
			{
				if (res.Left is Integer && res.Right is Integer)
				{
					return (res.Left as Integer).Value + (res.Right as Integer).Value;
				} else
				{
					return (res.Left as Real).Value + (res.Right as Real).Value;
				}
			}
			return res;
		}
		public override Expression On(Minus e)
		{
			var res = base.On(e) as Minus;
			if (res.Left is Literal && res.Right is Literal)
			{
				if (res.Left is Integer && res.Right is Integer)
				{
					return (res.Left as Integer).Value - (res.Right as Integer).Value;
				}
				else
				{
					return (res.Left as Real).Value - (res.Right as Real).Value;
				}
			}
			return res;
		}
		public override Expression On(Times e)
		{
			var res = base.On(e) as Times;
			if (res.Left is Literal && res.Right is Literal)
			{
				if (res.Left is Integer && res.Right is Integer)
				{
					return (res.Left as Integer).Value * (res.Right as Integer).Value;
				}
				else
				{
					return (res.Left as Real).Value * (res.Right as Real).Value;
				}
			}
			return res;
		}
		public override Expression On(Divide e)
		{
			var res = base.On(e) as Divide;
			if (res.Left is Literal && res.Right is Literal)
			{
				if (res.Left is Integer && res.Right is Integer)
				{
					return (res.Left as Integer).Value / (res.Right as Integer).Value;
				}
				else
				{
					return (res.Left as Real).Value / (res.Right as Real).Value;
				}
			}
			return res;
		}
	}
}
