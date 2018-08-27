using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroMunge
{
	public static class StringExt
	{
		/// <summary>
		/// Takes the substring of a string based on a start and end position instead of length.
		/// </summary>
		/// <param name="value">String to take the substring from.</param>
		/// <param name="startIndex">Index of the character in the string where the substring should start.</param>
		/// <param name="endIndex">Index of the character in the string where the substring should end.</param>
		/// <returns>Substring of the specified string.</returns>
		public static string SubstringIdx(this string value, int startIndex, int endIndex)
		{
			if (value == null) throw new ArgumentNullException();
			if (endIndex > value.Length) throw new IndexOutOfRangeException("End index must be less than or equal to the length of the string.");
			if (startIndex < 0 || startIndex > value.Length + 1) throw new IndexOutOfRangeException("Start index must be between zero and the length of the string minus one");
			if (startIndex >= endIndex) throw new ArgumentOutOfRangeException("Start index must be less than end index");

			var length = endIndex - startIndex;
			return value.Substring(startIndex, length);
		}
	}
}
