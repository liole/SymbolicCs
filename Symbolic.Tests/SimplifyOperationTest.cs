using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;

namespace Symbolic.Tests
{
	[TestClass]
	public class SimplifyOperationTest
	{
		[TestMethod]
		public void SimplifyPlus()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(x, _.Simplify(x+0)));
			Assert.IsTrue(_.Same(x, _.Simplify(0+x)));
			Assert.IsTrue(_.Same(0, _.Simplify((Integer)0+0)));
		}
		[TestMethod]
		public void SimplifyPlusDeep()
		{
			var x = new Symbol("x");
			var y = new Integer(-1);
			Assert.IsTrue(_.Same(x, _.Simplify(x+(1+y))));
		}
		[TestMethod]
		public void SimplifyMinus()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(x, _.Simplify(x-0)));
			Assert.IsTrue(_.Same(-x, _.Simplify(0-x)));
		}
		[TestMethod]
		public void SimplifyTimes()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(0, _.Simplify(x*0)));
			Assert.IsTrue(_.Same(x, _.Simplify(1*x)));
			Assert.IsTrue(_.Same(x, _.Simplify(x*1)));
		}
		[TestMethod]
		public void SimplifyDivide()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(0, _.Simplify(0/x)));
			Assert.IsTrue(_.Same(x/0, _.Simplify(x/0)));	// for now
			Assert.IsTrue(_.Same(x, _.Simplify(x/1)));
			Assert.IsTrue(_.Same(1/x, _.Simplify(1/x)));
		}
	}
}
