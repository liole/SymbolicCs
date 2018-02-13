using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;

namespace Symbolic.Tests
{
	[TestClass]
	public class CalculateOperationTest
	{
		[TestMethod]
		public void CalculateNothing()
		{
			var x = new Symbol("x");
			var exp = x + 2 * (5 - x);
			var res = _.Calculate(exp);
			Assert.IsTrue(_.Same(exp, res));
			Assert.AreNotSame(exp, true);
		}
		[TestMethod]
		public void CalculatePlus()
		{
			var x = new Integer(1);
			var res = _.Calculate(x+2) as Integer;
			Assert.IsNotNull(res);
			Assert.AreEqual(3, res.Value);
		}
		[TestMethod]
		public void CalculateMinus()
		{
			var x = new Integer(1);
			var res = _.Calculate(4-x) as Integer;
			Assert.IsNotNull(res);
			Assert.AreEqual(3, res.Value);
		}
		[TestMethod]
		public void CalculateTimes()
		{
			var x = new Integer(2);
			var res = _.Calculate(x*3) as Integer;
			Assert.IsNotNull(res);
			Assert.AreEqual(6, res.Value);
		}
		[TestMethod]
		public void CalculateDivide()
		{
			var x = new Integer(2);
			var res = _.Calculate(6/x) as Integer;
			Assert.IsNotNull(res);
			Assert.AreEqual(3, res.Value);
		}
		[TestMethod]
		public void CalculateMixed()
		{
			var x = new Integer(2);
			var y = new Integer(1);
			var res = _.Calculate(x+2*(y-6/x)) as Integer;
			Assert.IsNotNull(res);
			Assert.AreEqual(-2, res.Value);
		}
		[TestMethod]
		public void CalculateDeep()
		{
			var x = new Symbol("x");
			var y = new Integer(1);
			var res = _.Calculate(x+(3-y));
			Assert.IsTrue(_.Same(x+2, res));
		}
	}
}
