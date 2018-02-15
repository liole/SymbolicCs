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
		[TestMethod]
		public void SymbolImplicit()
		{
			var x = new Symbol("x");
			var exp = x + "y";
			Assert.AreEqual("x+y", exp.ToString());
			Assert.IsInstanceOfType((exp as BinaryOperator).Right, typeof(Symbol));
		}
		[TestMethod]
		public void SymbolFunctionCreate()
		{
			var x = new Symbol("x");
			var f = new SymbolFunction("f");
			var g = new SymbolFunction("g", x);
			Assert.AreEqual("f", f.Name);
			Assert.AreEqual(0, f.Arguments.Length);
			Assert.AreEqual("g", g.Name);
			Assert.AreEqual(1, g.Arguments.Length);
			var f1 = f._(x);
			Assert.AreEqual("f", f1.Name);
			Assert.AreEqual(1, f1.Arguments.Length);
		}
		[TestMethod]
		public void SymbolFunctionString()
		{
			var x = new Symbol("x");
			var f = new SymbolFunction("f");
			var g = new SymbolFunction("g", x);
			Assert.AreEqual("f[]", f.ToString());
			Assert.AreEqual("g[x]", g.ToString());
			Assert.AreEqual("f[x,x+1]", f._(x, x+1).ToString());
		}
		[TestMethod]
		public void SymbolFunctionDerivative()
		{
			var x = new Symbol("x");
			var f = new SymbolFunction("f", x).D();
			var g = new SymbolFunction("g", x, x).D(0).D(1).D(1);
			Assert.AreEqual("f'[x]", f.ToString());
			Assert.AreEqual("g<1,2>[x,x]", g.ToString());
		}
	}
}
