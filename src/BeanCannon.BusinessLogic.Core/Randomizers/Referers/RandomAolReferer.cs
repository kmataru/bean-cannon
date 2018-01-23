using System;

namespace BeanCannon.BusinessLogic.Core.Randomizers.Referers
{
	public class RandomAolReferer : IRandomReferer
	{
		public string FormattedUrl { get; } = "https://search.aol.com/aol/search;_ylt={1};_ylc={2}-?p={0}&fr=&fr2=sb-top-&s_it=sb-home&iscqry=";

		public RandomAolReferer()
		{
		}

		public string GetRandomElement(string query)
		{
			// _ylt=A0LEVxpsGVZaw8UAKR9oCWVH
			var randomYltQueryParameter = $"{RandomizerHq.RandomString(24)}";

			// _ylc=X1MDMTE5NzgwMzg4MARfcgMyBGZyAwRncHJpZAN0alVrSW5hWFJ1ZTZ2VFhJNS45ek1BBG5fcnNsdAMwBG5fc3VnZwMxMARvcmlnaW4Dc2VhcmNoLmFvbC5jb20EcG9zAzAEcHFzdHIDBHBxc3RybAMEcXN0cmwDNgRxdWVyeQNzYWxvbngEdF9zdG1wAzE1MTU1OTIwNDk
			var randomYlcQueryParameter = $"{RandomizerHq.RandomString(203)}";

			return String.Format(
				FormattedUrl,
				query, randomYltQueryParameter, randomYlcQueryParameter
				);
		}
	}
}
