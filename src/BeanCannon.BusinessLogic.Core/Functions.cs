/* LOIC - Low Orbit Ion Cannon
 * Released to the public domain
 * Enjoy getting v&, kids.
 */

using System;
using System.Diagnostics;

namespace BeanCannon.BusinessLogic.Core
{
	public static class Functions
	{
		public static bool ParseInt(string str, int min, int max, out int value)
		{
			bool res = int.TryParse(str, out value);

			if (res && value >= min && value <= max)
				return true;

			return false;
		}
	}

	public static class Format
	{
		static string[] sizeSuffixes = { String.Empty, "K", "M", "G", "T", "P", "E", "Z", "Y" };

		public static string Size(long size)
		{
			Debug.Assert(sizeSuffixes.Length > 0);

			const string formatTemplate = "{0}{1:0.#}{2}";

			if (size == 0)
			{
				return string.Format(formatTemplate, null, 0, sizeSuffixes[0]);
			}

			var absSize = Math.Abs((double)size);
			var fpPower = Math.Log(absSize, 1000);
			var intPower = (int)fpPower;
			var iUnit = intPower >= sizeSuffixes.Length
				? sizeSuffixes.Length - 1
				: intPower;
			var normSize = absSize / Math.Pow(1000, iUnit);

			return string.Format(
				formatTemplate,
				size < 0 ? "-" : null, normSize, sizeSuffixes[iUnit]);
		}
	}
}
