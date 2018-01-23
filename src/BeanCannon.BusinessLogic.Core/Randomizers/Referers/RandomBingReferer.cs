using System;

namespace BeanCannon.BusinessLogic.Core.Randomizers.Referers
{
	public class RandomBingReferer : IRandomReferer
	{
		public string FormattedUrl { get; } = "https://www.bing.com/search?q={0}&qs=n&form=QBLH&sp=-1&pq={0}&sc=8-6&sk=&cvid={1}";

		public RandomBingReferer()
		{
		}

		public string GetRandomElement(string query)
		{
			// cvid=CDF2BB1B133A4284A238464D3D8A62FA
			var randomCvidQueryParameter = $"{RandomizerHq.RandomString(30)}";

			return String.Format(
				FormattedUrl,
				query, randomCvidQueryParameter
				);
		}
	}
}
