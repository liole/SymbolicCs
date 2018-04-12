using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbolic.Expressions;
using Symbolic.Expressions.Functions;
using Symbolic.Expressions.Operators;

namespace Symbolic.Operations
{
	class Simplify : Calculate
	{
		public override Expression On(Pow e)
		{
			var res = base.On(e);
			if (res is Pow)
			{
				var resB = res as Pow;
				if (_.Same(resB.Arguments[0], 0))
				{
					return 0;
				}
				if (_.Same(resB.Arguments[1], 0))
				{
					return 1;
				}
				if (_.Same(resB.Arguments[1], 1))
				{
					return resB.Arguments[0];
				}
				if (_.Same(resB.Arguments[1], 0.5)) // simplification ?
				{
					return _.Sqrt(resB.Arguments[0]);
				}
			}
			return res;
		}
		public override Expression On(Plus e)
		{
			var res = base.On(e);
			if (res is Plus)
			{
				var resB = res as Plus;
				if (_.Same(resB.Left, 0))
				{
					return resB.Right;
				}
				if (_.Same(resB.Right, 0))
				{
					return resB.Left;
				}
			}
			return res;
		}
		public override Expression On(Minus e)
		{
			var res = base.On(e);
			if (res is Minus)
			{
				var resB = res as Minus;
				if (_.Same(resB.Left, 0))
				{
					return -resB.Right;
				}
				if (_.Same(resB.Right, 0))
				{
					return resB.Left;
				}
				if (_.Equal(resB.Left, resB.Right))
				{
					return 0;
				}
				if (resB.Left is Plus)
				{
					var leftB = resB.Left as BinaryOperator;
					if (_.Equal(leftB.Right, resB.Right))
					{
						return leftB.Left;
					}
				}
			}
			return res;
		}
		public override Expression On(Times e)
		{
			var res = base.On(e);
			if (res is Times)
			{
				var resB = res as Times;
				if (_.Same(resB.Left, 0) || _.Same(resB.Right, 0))
				{
					return 0;
				}
				if (_.Same(resB.Left, 1))
				{
					return resB.Right;
				}
				if (_.Same(resB.Right, 1))
				{
					return resB.Left;
				}
			}
			return res;
		}
		public override Expression On(Divide e)
		{
			var res = base.On(e);
			if (res is Divide)
			{
				var resB = res as Divide; 
				if (_.Same(resB.Left, 0))
				{
					return 0;
				}
				if (_.Same(resB.Right, 1))
				{
					return resB.Left;
				}
			}
			return res;
		}
	}
}
