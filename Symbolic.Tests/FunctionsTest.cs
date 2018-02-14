using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Expressions.Functions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;

namespace Symbolic.Tests
{
	[TestClass]
	public class FunctionsTest
	{
		[TestMethod]
		public void FunctionCreate()
		{
			var x = new Symbol("x");
			var sin = _.Sin(x);
			var cos = _.Cos(1);
			Assert.IsInstanceOfType(sin, typeof(Sin));
			Assert.IsInstanceOfType(cos, typeof(Cos));
			
			Assert.AreEqual(x, (sin as Function).Arguments[0]);
			Assert.IsInstanceOfType((cos as Function).Arguments[0], typeof(Integer));
		}
		[TestMethod]
		public void FunctionString()
		{
			var x = new Symbol("x");
			var res1 = _.Sqrt(x);
			var res2 = _.Exp(x);
			Assert.AreEqual("sqrt[x]", res1.ToString());
			Assert.AreEqual("exp[x]", res2.ToString());
		}
		[TestMethod]
		public void FunctionComposite()
		{
			var x = new Symbol("x");
			var res = _.Sin(x+2);
			Assert.AreEqual("sin[x+2]", res.ToString());
		}
	}
}
