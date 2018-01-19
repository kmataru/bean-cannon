using System;

namespace BeanCannon.BusinessLogic.Core.Randomizers.Referers
{
	public class RandomYahooReferer : IRandomReferer
	{
		public string FormattedUrl { get; } = "https://search.yahoo.com/search;_ylt={1};_ylc={2}?p={0}&fr=sfp&fr2=sb-top-search&iscqry=";

		public RandomYahooReferer()
		{
		}

		public string GetRandomElement(string query)
		{
			// _ylt=A2KLfSO_EVZaVAMAcm5DDWVH
			var randomYltQueryParameter = $"{RandomizerHq.RandomString(7)}_{RandomizerHq.RandomString(15)}";

			// _ylc=X1MDMTE5NzgwNDg2NwRfcgMyBGZyAwRncHJpZANQS2RKMDZWU1N4S2Mybk4yNzJSa0RBBG5fcnNsdAMwBG5fc3VnZwM5BG9yaWdpbgNzZWFyY2gueWFob28uY29tBHBvcwMwBHBxc3RyAwRwcXN0cmwDBHFzdHJsAzYEcXVlcnkDc2Fsb254BHRfc3RtcAMxNTE1NTkwMDk3
			var randomYlcQueryParameter = $"{RandomizerHq.RandomString(204)}";

			return String.Format(
				FormattedUrl,
				query, randomYltQueryParameter, randomYlcQueryParameter
				);
		}
	}
}
