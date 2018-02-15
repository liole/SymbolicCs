using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Operations;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;
using System.Linq;

namespace Symbolic.Tests
{
	[TestClass]
	public class DerivativeTest
	{
		[TestMethod]
		public void VariableCounter()
		{
			var x = new Symbol("x");
			var y = new Symbol("y");
			Assert.AreEqual(1, (x+2).Symbols().Count());
			Assert.AreEqual(1, (x*(3-_.Sin(x/_.Pi))).Symbols().Count());
			Assert.AreEqual(2, (x*(3-_.Sin(y/_.Pi))).Symbols().Count());
		}
		[TestMethod]
		public void DerivativeConst()
		{
			Assert.IsTrue(_.Same(0, _.D(1)));
		}
		[TestMethod]
		public void DerivativeVariable()
		{

			var x = new Symbol("x");
			Assert.IsTrue(_.Same(1, x.Prime()));
		}
		[TestMethod]
		public void DerivativeAdditive()
		{

			var x = new Symbol("x");
			Assert.IsTrue(_.Same(2, _.D(x+x-1)));
			Assert.IsTrue(_.Same(-1, _.D(x - 2*x)));
		}
		[TestMethod]
		public void DerivativeMultiplicative()
		{

			var x = new Symbol("x");
			Assert.IsTrue(_.Same(_.Sin(x)+x*_.Cos(x), _.D(x*_.Sin(x))));
			Assert.IsTrue(_.Same((_.Cos(x)*x-_.Sin(x))/_.Pow(x,2), _.D(_.Sin(x)/x)));
		}
		[TestMethod]
		public void DerivativeExponentioal()
		{

			var x = new Symbol("x");
			Assert.IsTrue(_.Same(2*x, _.D(_.Pow(x,2))));
			Assert.IsTrue(_.Same(1/(2*_.Sqrt(x)), _.D(_.Sqrt(x))));
			Assert.IsTrue(_.Same(_.Exp(x), _.D(_.Exp(x))));
			// not yet: Assert.IsTrue(_.Same(_.Pow(x,x)*(1+_.Ln(x)),
			Assert.IsTrue(_.Same(_.Pow(x,x-1)*(x+x*_.Ln(x)),
				_.D(_.Pow(x, x))));
		}
		[TestMethod]
		public void DerivativeLogarythmic()
		{

			var x = new Symbol("x");
			Assert.IsTrue(_.Same(1/x, _.D(_.Ln(x))));
			Assert.IsTrue(_.Same(1/(x*_.Ln(10)), _.D(_.Lg(x))));
			// not yet: _.D(_.Log(2*x, x)) - too complicated answer, yet correct
		}
		[TestMethod]
		public void DerivativeExternalVariable()
		{
			var x = new Symbol("x");
			var y = new Symbol("y");
			Assert.IsTrue(_.Same(0, (x+3*_.Ln(x)).Prime(y)));
		}
		[TestMethod]
		public void DerivativeFunctionVariable()
		{
			var x = new Symbol("x");
			var y = new Symbol("y");
			var f = new SymbolFunction("f", x, 2*x, y, _.Pow(x,2));
			Assert.AreEqual(
				"f<1,0,0,0>[x,2*x,y,pow[x,2]]+f<0,1,0,0>[x,2*x,y,pow[x,2]]*2+f<0,0,0,1>[x,2*x,y,pow[x,2]]*2*x",
				_.D(f, x).ToString()
			);
			// needs canonical form (not the same tree, yet the same expression)
			//Assert.IsTrue(_.Same(
			//	f.D(0) + f.D(1)*2 + f.D(3)*2*x,
			//	_.D(f, x)
			//));
		}
		[TestMethod]
		public void DerivativeFormula()
		{
			var x = new Symbol("x");
			var f = new SymbolFunction("f", x);
			var g = new SymbolFunction("g", x);
			Assert.AreEqual("f'[x]*g[x]+f[x]*g'[x]", 
				_.D(f*g).ToString());
			Assert.AreEqual("pow[f[x],g[x]-1]*(f'[x]*g[x]+f[x]*g'[x]*ln[f[x]])",
				_.D(_.Pow(f, g)).ToString());
		}
	}
}
