using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;

namespace Symbolic.Tests
{
	[TestClass]
	public class SameOperationTest
	{
		[TestMethod]
		public void SameSymbol()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(x, x));
		}
		[TestMethod]
		public void SameSymbolName()
		{
			var x = new Symbol("x");
			var y = new Symbol("x");
			Assert.IsTrue(_.Same(x, y));
		}
		[TestMethod]
		public void SameLiteral()
		{
			Assert.IsTrue(_.Same(1, 1));
			Assert.IsFalse(_.Same(1, 2));
			Assert.IsTrue(_.Same(true, true));
			Assert.IsFalse(_.Same(false, true));
		}
		[TestMethod]
		public void SameMixed()
		{
			var x = new Symbol("x");
			Assert.IsFalse(_.Same(x, 1));
			Assert.IsFalse(_.Same(1, true));
			Assert.IsFalse(_.Same(true, x));
			Assert.IsFalse(_.Same(x, x+1));
		}
		[TestMethod]
		public void SameFunction()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(_.Sin(1), _.Sin(1)));
			Assert.IsFalse(_.Same(_.Sin(1), _.Cos(1)));
			Assert.IsFalse(_.Same(_.Sin(1), _.Sin(x)));
		}
		[TestMethod]
		public void SameOperator()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(x+1, x+1));
			Assert.IsFalse(_.Same(x+1, x-1));
			Assert.IsFalse(_.Same(x+1, 2+x));
		}
		[TestMethod]
		public void SameDeep()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(_.Sin(x+1), _.Sin(x+1)));
			Assert.IsFalse(_.Same(_.Sin(x+1), _.Cos(x)));
			Assert.IsFalse(_.Same(_.Sin(x+2), _.Sin(1+5*x)));
			Assert.IsTrue(_.Same(_.Sin(1+3*_.Cos(x)), _.Sin(1+3*_.Cos(x))));
		}
	}
}
