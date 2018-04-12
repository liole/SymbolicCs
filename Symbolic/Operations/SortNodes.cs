using Symbolic.Expressions;
using Symbolic.Expressions.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Operations
{
	class SortNodes : Clone
	{
		// only for normalized nodes
		public override Expression On(Times e)
		{
			if (e.Left is Times)
			{
				var left = e.Left.Perform(new SortNodes()) as Times;
				var right = e.Right;
				if (Compare(left.Right, e.Right) > 0)
				{
					right = left.Right;
					left = (left.Left * e.Right).Perform(new SortNodes()) as Times;
				}
				return left * right;
			}
			if (Compare(e.Left, e.Right) > 0)
			{
				return e.Right * e.Left;
			}
			return e.Left * e.Right;
		}
		//public override Expression On(Plus e)
		//{
		//	return OnPlusMinus(e);
		//}
		//public override Expression On(Minus e)
		//{
		//	return OnPlusMinus(e);
		//}
		public Expression OnPlusMinus(BinaryOperator e)
		{
			var plus = e is Plus;
			if (e.Left is Plus || e.Left is Minus)
			{
				var left = e.Left.Perform(new SortNodes()) as BinaryOperator;
				var leftPlus = left is Plus;
				var right = e.Right;
				var cmp = Compare(left.Right, e.Right);
				if (cmp > 0 || cmp==0 && plus && !leftPlus)
				{
					right = left.Right;
					left = OpPM(plus, left.Left, e.Right).Perform(new SortNodes()) as BinaryOperator;
					plus = leftPlus;
				}
				return OpPM(plus, left, right);
			}
			var leftArg = e.Left;
			var unaryM = leftArg is UnaryMinus;
			if (unaryM)
			{
				leftArg = (leftArg as UnaryMinus).Argument;
			}
			var cmpU = Compare(leftArg, e.Right);
			if (cmpU > 0 || cmpU == 0 && plus && unaryM)
			{
				if (plus)
				{
					return OpPM(!unaryM, e.Right, leftArg);
				}
				else
				{
					return OpPM(!unaryM, -e.Right, leftArg); ;
				}
			}
			return OpPM(plus, e.Left, e.Right);
		}
		public BinaryOperator OpPM(bool plus, Expression a, Expression b)
		{
			if (plus)
			{
				return a + b as BinaryOperator;
			}
			else
			{
				return a - b as BinaryOperator;
			}
		}
		public static int Compare(Expression a, Expression b)
		{
			if (a is Literal)
			{
				if (b is Literal)
				{
					return (a as Literal).CompareTo(b as Literal);
				}
				return -1;
			}
			else if (a is Symbol)
			{
				if (b is Literal)
				{
					return 1;
				}
				if (b is Symbol)
				{
					return (a as Symbol).Name.CompareTo((b as Symbol).Name);
				}
				return -1;
			}
			// everything else is a function
			else if (a is Function)
			{
				if (b is Literal || b is Symbol)
				{
					return 1;
				}
				if (b is Function)
				{
					var af = a as Function;
					var bf = b as Function;
					var res = af.Name.CompareTo(bf.Name);
					if (res == 0)
					{
						if (af is SymbolFunction && bf is SymbolFunction)
						{
							var afs = af as SymbolFunction;
							var bfs = bf as SymbolFunction;
							res = res = afs.Derivatives
								.Zip(bfs.Derivatives, (afsd, bfsd) => afsd -bfsd)
								.FirstOrDefault(c => c != 0);
						}
						if (res == 0)
						{
							res = af.Arguments.Length - bf.Arguments.Length;
							if (res == 0)
							{
								res = af.Arguments
									.Zip(bf.Arguments, (afa, bfa) => Compare(afa, bfa))
									.FirstOrDefault(c => c != 0);
							}
						}
					}
					return res;
				}
				return -1;
			}
			return -1;
		}
	}
}
