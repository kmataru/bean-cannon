using BeanCannon.BusinessLogic.Core.Collections;
using BeanCannon.BusinessLogic.Core.Randomizers.Referers;
using System;

namespace BeanCannon.BusinessLogic.Core.Randomizers
{
	class RandomReferer
	{
		// Read more @ https://en.wikipedia.org/wiki/List_of_search_engines
		/*
			('http://' + host + '/')
		*/
		private static readonly IRandomReferer[] referers = {
			new RandomGoogleReferer(),
			new RandomBaiduReferer(),
			new RandomBingReferer(),
			new RandomYahooReferer(),
			new RandomYandexReferer(),
			new RandomAolReferer(),
		};

		CircularList<int> referersCircularList;

		public RandomReferer()
		{
			var referersLength = referers.Length;

			referersCircularList =
				new CircularList<int>(() => new UniqueRandomizer().GenerateRandom(referersLength, 0, referersLength));
		}

		public string GetRandomElement()
		{
			var value = referersCircularList.Value;
			referersCircularList.Next();

			var referer = referers[value];

			var query = RandomizerHq.RandomString(RandomizerHq.RandomInt(6, 15));
			return referer.GetRandomElement(query);
		}
	}
}
