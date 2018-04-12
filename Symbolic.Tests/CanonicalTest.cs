using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbolic.Expressions;
using Symbolic.Expressions.Literals;
using Symbolic.Expressions.Operators;
using Symbolic.Operations;

namespace Symbolic.Tests
{
	[TestClass]
	public class CanonicalTest
	{
		[TestMethod]
		public void NormializeTimes()
		{
			var x = new Symbol("x");
			var y = new Symbol("y");
			Assert.IsTrue(_.Same(
				((x*1)*y)*2, 
				(x*(1*(y*2))).Normalize()
			));
		}
		[TestMethod]
		public void NormalizeDivide()
		{
			var x = new Symbol("x");
			var y = new Symbol("y");
			Assert.IsTrue(_.Same(
				(x*1*3)/(y*2*x*y), 
				(x*(1/y)/((2*x)/(3/y))).Normalize()
			));
		}
		[TestMethod]
		public void NormalizePlusMinus()
		{
			var x = new Symbol("x");
			var y = new Symbol("y");
			Assert.IsTrue(_.Same(
				(((-x + y) - 3) + x),
				(-x + ((y - 3) + x)).Normalize()
			));
		}
		[TestMethod]
		public void NormalizeMinusPlus()
		{
			var x = new Symbol("x");
			var y = new Symbol("y");
			Assert.IsTrue(_.Same(
				(((-x + y) - 3) + x),
				(-x + y - (3 - x)).Normalize()
			));
		}
		[TestMethod]
		public void CanonicalSortTimes()
		{
			var x = new Symbol("x");
			var y = new Symbol("y");
			Assert.IsTrue(_.Same(
				(Integer)1*2*x*y*(x+y)*(y+2)*(x+y+3)*_.Cos(y)*_.Sin(x), 
				(_.Cos(y)*2*y*1*(y+2)*(x+y+3)*(x + y)*_.Sin(x)*x).Canonical()
			));
		}
		[TestMethod]
		public void CanonicalSortPlus()
		{
			var x = new Symbol("x");
			var y = new Symbol("y");
			var res = (_.Cos(y) + 2 - y - 1 + (y + 2) + y + x * y * + _.Sin(x) + x).Canonical();
			Assert.IsTrue(_.Same(
				-((Integer)1) + 2 + x + y - y + x * y + _.Cos(y) + _.Sin(x),
				(_.Cos(y) + 2 - y - 1 + (y + 2) + y + x * y + _.Sin(x) + x).Canonical()
			));
		}
	}
}
