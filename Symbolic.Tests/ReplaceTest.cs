using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;
using Symbolic.Operations;

namespace Symbolic.Tests
{
	[TestClass]
	public class ReplaceTest
	{
		[TestMethod]
		public void ReplaceSymbol()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(1, x.Replace(new Rule(x, 1))));
		}
		[TestMethod]
		public void ReplaceSymbolDeep()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(1+_.Sin(1), (x+_.Sin(x)).Replace(new Rule(x, 1))));
		}
		[TestMethod]
		public void PatterMatch()
		{
			var x = new Symbol("x");
			var y = new Symbol("y");
			Assert.IsTrue((~x+1).Match(x+1));
			Assert.IsTrue((~x+1).Match(y+1));
			Assert.IsTrue((~x+1).Match((2*x)+1));
			Assert.IsFalse((~x+1).Match(x-1));
		}
		[TestMethod]
		public void PatterRules()
		{
			var x = new Symbol("x");
			Rule[] rules;
			Assert.IsTrue((_.Sin(~x)).Match(_.Sin(x+1), out rules));
			Assert.AreEqual(1, rules.Length);
			Assert.IsTrue(_.Same(new Rule(x, x+1), rules[0]));
		}
		[TestMethod]
		public void ReplacePatternSymbol()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(1+x, (_.Sin(x)+x).Replace(
				new Rule(_.Sin(~x), 1))));
		}
		[TestMethod]
		public void ReplacePatternExpression()
		{
			var x = new Symbol("x");
			Assert.IsTrue(_.Same(_.Cos(1+2*x)+x, (_.Sin(2*x)+x).Replace(
				new Rule(_.Sin(~x), _.Cos(1+x)))));
		}
		[TestMethod]
		public void ReplaceFunction()
		{
			var x = new Symbol("x");
			var f = new SymbolFunction("f");
			Assert.IsTrue(_.Same(1+2*(x+2), (1+f._(x+2)).Replace(
				new Rule(f._(~x),2*x))));
		}
		[TestMethod]
		public void ReplaceFunctionDerivative()
		{
			var x = new Symbol("x");
			var f = new SymbolFunction("f", x);
			Assert.IsTrue(_.Same(1+2*x, (1+f.D()._(x)).Replace(
				new Rule(f._(~x),_.Pow(x,2)))));
			Assert.IsTrue(_.Same(4*x, (f.D()._(2*x)).Replace(
				new Rule(f._(~x), _.Pow(x, 2)))));
		}
		[TestMethod]
		public void RuloOperator()
		{
			var x = new Symbol("x");
			var rule = x >> 1;
			Assert.IsInstanceOfType(rule, typeof(Rule));
			Assert.IsTrue(_.Same(new Rule(x, 1), rule));
		}
	}
}
