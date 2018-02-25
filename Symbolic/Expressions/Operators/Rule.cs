using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions.Operators
{
	public class Rule : BinaryOperator
	{
		public static Dictionary<int, Expression> HashTable = new Dictionary<int, Expression>();
		public override string Sign => ">>";
		public override int Priority => 0;
		//public Rule(Expression left, Expression right) :
		//	base(left, right)
		//{
		//}
		public Rule(Expression left, int right):
			base(left, right)
		{
			if (HashTable.ContainsKey(right))
			{
				Right = HashTable[right];
			}
		}
		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
	}
}
