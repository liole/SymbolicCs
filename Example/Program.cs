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
		}
	}
}
