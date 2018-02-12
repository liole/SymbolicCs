using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;

namespace Symbolic.Tests
{
	[TestClass]
	public class SymbolsTest
	{
		[TestMethod]
		public void SymbolCreate()
		{
			var x = new Symbol("x");
			Assert.AreEqual("x", x.ToString());
		}
	}
}
