using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions
{
	public enum SeparatorType
	{
		Comma,
		Semicolon
	}
	public static class SeparatorTypeValues
	{
		public static string Value(this SeparatorType type)
		{
			switch (type)
			{
				case SeparatorType.Comma:
					return ",";
				case SeparatorType.Semicolon:
					return ";";
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
