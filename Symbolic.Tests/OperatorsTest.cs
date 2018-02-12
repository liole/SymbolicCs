using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;

namespace Symbolic.Tests
{
	[TestClass]
	public class OperatorsTest
	{
		[TestMethod]
		public void OperatorCreate()
		{
			var x = new Symbol("x");
			var plus = x + 1;
			var minus = x - 2;
			var times = x * 3;
			var divide = x / 4;
			Assert.IsInstanceOfType(plus, typeof(Plus));
			Assert.IsInstanceOfType(minus, typeof(Minus));
			Assert.IsInstanceOfType(times, typeof(Times));
			Assert.IsInstanceOfType(divide, typeof(Divide));

			var res = plus as BinaryOperator;
			Assert.AreEqual(x, res.Left);
			Assert.IsInstanceOfType(res.Right, typeof(Integer));
		}
		[TestMethod]
		public void OperatorString()
		{
			var x = new Symbol("x");
			var res = x + 2;
			Assert.AreEqual("x+2", res.ToString());
		}
		[TestMethod]
		public void OperatorPriority()
		{
			var x = new Symbol("x");
			var res = 2 + 3 * x;
			Assert.IsInstanceOfType(res, typeof(Plus));
			Assert.IsInstanceOfType((res as BinaryOperator).Right, typeof(Times));
		}
		[TestMethod]
		public void OperatorBrackets()
		{
			var x = new Symbol("x");
			var res1 = x + 3 * x;
			var res2 = (x + 3) * x;
			Assert.AreEqual("x+3*x", res1.ToString());
			Assert.AreEqual("(x+3)*x", res2.ToString());
		}
	}
}
