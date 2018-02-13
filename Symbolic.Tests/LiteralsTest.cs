using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Expressions.Literals;

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
	}
}
