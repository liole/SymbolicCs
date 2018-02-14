using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Literals.Constants;

namespace Symbolic.Tests
{
	[TestClass]
	public class LiteralsTest
	{
		[TestMethod]
		public void IntegerCreate()
		{
			var i = new Integer(5);
			Assert.AreEqual(5, i.Value);
		}
		[TestMethod]
		public void IntegerImplicit()
		{
			Integer i = 5;
			Assert.AreEqual(5, i.Value);
		}
		[TestMethod]
		public void IntegerConvert()
		{
			var i = new Integer(5);
			Assert.AreEqual(5, (int)i);
		}
		[TestMethod]
		public void IntegerString()
		{
			var i = new Integer(5);
			Assert.AreEqual("5", i.ToString());
		}

		[TestMethod]
		public void RealCreate()
		{
			var d = new Real(5.1);
			Assert.AreEqual(5.1, d.Value);
		}
		[TestMethod]
		public void RelaImplicit()
		{
			Real d = 5.1;
			Assert.AreEqual(5.1, d.Value);
		}
		[TestMethod]
		public void RealConvert()
		{
			var d = new Real(5.1);
			Assert.AreEqual(5.1, (double)d);
		}

		[TestMethod]
		public void LogicalCreate()
		{
			var b = new Logical(true);
			Assert.AreEqual(true, b.Value);
		}
		[TestMethod]
		public void LogicalImplicit()
		{
			Logical b = false;
			Assert.AreEqual(false, b.Value);
		}
		[TestMethod]
		public void LogicalConvert()
		{
			var b = new Logical(true);
			Assert.AreEqual(true, (bool)b);
		}
		[TestMethod]
		public void IntegerIsReal()
		{
			Integer i = 5;
			Assert.IsTrue(i is Real);
			Assert.AreEqual((i as Real).Value, 5.0);
		}
		[TestMethod]
		public void ConstCreate()
		{
			Expression one = 1;
			Expression pi = Math.PI;
			Assert.IsInstanceOfType(one, typeof(One));
			Assert.IsInstanceOfType(pi, typeof(Pi));
		}
		[TestMethod]
		public void ConstString()
		{
			Expression one = 1;
			Expression pi = Math.PI;
			Expression e = Math.E;
			Assert.AreEqual("1", one.ToString());
			Assert.AreEqual("pi", pi.ToString());
			Assert.AreEqual("e", e.ToString());
		}
	}
}
