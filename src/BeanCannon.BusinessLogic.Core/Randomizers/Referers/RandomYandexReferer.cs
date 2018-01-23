using System;

namespace BeanCannon.BusinessLogic.Core.Randomizers.Referers
{
	public class RandomYandexReferer : IRandomReferer
	{
		public string FormattedUrl { get; } = "https://www.yandex.com/search/?msid={1}&text={0}&lr={2}";

		public RandomYandexReferer()
		{
		}

		public string GetRandomElement(string query)
		{
			// msid=1515590448.92777.22891.11544
			var randomNumbers = new int[] {
				RandomizerHq.RandomInt(10000, 99999),
				RandomizerHq.RandomInt(10000, 99999),
				RandomizerHq.RandomInt(10000, 99999),
				RandomizerHq.RandomInt(10000, 99999),
				RandomizerHq.RandomInt(10000, 99999),
			};
			var randomMsidQueryParameter = $"{randomNumbers[0]}{randomNumbers[1]}.{randomNumbers[2]}.{randomNumbers[3]}.{randomNumbers[4]}";

			// lr=105364
			var randomLrTQueryParameter = $"{RandomizerHq.RandomInt(100000, 999999)}";

			return String.Format(
				FormattedUrl,
				query, randomMsidQueryParameter, randomLrTQueryParameter
				);
		}
	}
}
