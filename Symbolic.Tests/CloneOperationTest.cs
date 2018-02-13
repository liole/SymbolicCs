using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Operations;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;

namespace Symbolic.Tests
{
	[TestClass]
	public class CloneOperationTest
	{
		[TestMethod]
		public void CloneSymbol()
		{
			var x = new Symbol("x");
			var y = x.Clone();
			Assert.IsTrue(_.Same(x, y));
			Assert.AreNotSame(x, y);
		}
		[TestMethod]
		public void CloneLiteral()
		{
			var a = new Integer(1);
			var a1 = a.Clone();
			var b = new Logical(true);
			var b1 = b.Clone();
			Assert.IsTrue(_.Same(a, a1));
			Assert.AreNotSame(a, a1);
			Assert.IsTrue(_.Same(b, b1));
			Assert.AreNotSame(b, b1);
		}
		[TestMethod]
		public void CloneFunction()
		{
			var x = new Symbol("x");
			var s = _.Sin(x+1);
			var s1 = s.Clone();
			Assert.IsTrue(_.Same(s, s1));
			Assert.AreNotSame(s, s1);
		}
		[TestMethod]
		public void CloneOperator()
		{
			var x = new Symbol("x");
			var s = 2+x;
			var s1 = s.Clone();
			Assert.IsTrue(_.Same(s, s1));
			Assert.AreNotSame(s, s1);
		}
	}
}
