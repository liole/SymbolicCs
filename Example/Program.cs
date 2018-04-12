using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbolic.Expressions;
using Symbolic;
using Symbolic.Operations;
using static Symbolic._;
using Symbolic.Expressions.Operators;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			var x = new Symbol("x");
			var f = new SymbolFunction("f");
			var res1 = D(Sin(f[2*x]));
			Console.WriteLine(res1.ToString());
			var res2 = res1.Replace(f[~x] >> Pow(x, 2));
			Console.WriteLine(res2.ToString());
			var res3 = res1.Replace(f[x] >> Pow(x, 2));
			Console.WriteLine(res3.ToString());
			var res4 = res1.Replace(f[2*x] >> Pow(x, 3));
			Console.WriteLine(res4.ToString());
			var res5 = res1.Replace(f[2*~x] >> Pow(x, 3));
			Console.WriteLine(res5.ToString());
			var res6 = (x + 2 * x - Pow(x, 2)+Sin(x)).Replace(x >> -4);
			Console.WriteLine(res6.ToString());
			var y  = new Symbol("y");
			var res7 = -x + 2 - 4+3*x + y - 5 - (-x) +1-1;
			Console.WriteLine(res7.Canonical().ToString());
			var res8 = res7.Simplify();
			Console.WriteLine(res8.Canonical().ToString());
			var res9 = ((x + 1) + 2).Replace((Expression)1+2 >> 5);
			Console.WriteLine(res9.ToString());
		}
	}
}
