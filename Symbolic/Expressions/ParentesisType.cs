using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic.Expressions
{
	public enum BracketsType
	{
		Round,
		Square,
		Curly,
		Angle
	}
	public static class ParentesisTypeValues
	{
		public static string Open(this BracketsType type)
		{
			switch (type)
			{
				case BracketsType.Round:
					return "(";
				case BracketsType.Square:
					return "[";
				case BracketsType.Curly:
					return "{";
				case BracketsType.Angle:
					return "<";
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public static string Close(this BracketsType type)
		{
			switch (type)
			{
				case BracketsType.Round:
					return ")";
				case BracketsType.Square:
					return "]";
				case BracketsType.Curly:
					return "}";
				case BracketsType.Angle:
					return ">";
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
