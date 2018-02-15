using Symbolic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions
{
	public class SymbolFunction: Function
	{
		public static BracketsType DerivativeBracketsType = BracketsType.Angle;
		private string name;
		public override string Name => name;
		public int[] Derivatives { get; protected set; }
		public SymbolFunction(string name, params Expression[] defaultArgs):
			base(defaultArgs)
		{
			this.name = name;
			Derivatives = new int[defaultArgs.Length];
		}
		public SymbolFunction(SymbolFunction f, params Expression[] args) :
			base(args)
		{
			this.name = f.Name;
			if (args.Length <= f.Derivatives.Length)
			{
				Derivatives = f.Derivatives.Take(args.Length).ToArray();
			}
			else
			{
				Derivatives = f.Derivatives
					.Concat(new int[args.Length - f.Derivatives.Length])
					.ToArray();
			}
			var lastD = Array.FindLastIndex(Derivatives, d => d != 0);
			if (lastD >= args.Length)
			{
				throw new ArgumentException();
			}
		}

		public SymbolFunction _(params Expression[] args)
		{
			return new SymbolFunction(this, args);
		}
		public SymbolFunction D(int index = 0)
		{
			var f = new SymbolFunction(this, Arguments);
			f.Derivatives[index]++;
			return f;
		}

		public override Expression Perform(Operation operation)
		{
			return operation.On(this);
		}
		public override string ToString()
		{
			var currName = name;
			var sb = new StringBuilder(name);
			if (Derivatives.Any(d => d != 0))
			{
				if (Arguments.Length == 1)
				{
					sb.Append(new String('\'', Derivatives[0]));
				}
				else
				{
					sb.Append(DerivativeBracketsType.Open());
					sb.Append(String.Join(SeparatorType.Value(), Derivatives));
					sb.Append(DerivativeBracketsType.Close());
				}
			}
			name = sb.ToString();
			var res = base.ToString();
			name = currName;
			return res;
		}
	}
}
