using System;

namespace BeanCannon.BusinessLogic.Core.Randomizers.Referers
{
	public class RandomBaiduReferer : IRandomReferer
	{
		public string FormattedUrl { get; } = "https://www.baidu.com/s?ie=utf-8&f=8&rsv_bp=0&rsv_idx=1&tn=baidu&wd={0}&rsv_pq={1}&rsv_t={2}&rqlang=cn&rsv_enter=1&rsv_n=2&rsv_sug3=1";

		public RandomBaiduReferer()
		{
		}

		public string GetRandomElement(string query)
		{
			// rsv_pq=aac84da500005970
			var randomRsvPqQueryParameter = $"{RandomizerHq.RandomString(15)}";

			// rsv_t=864eH5GApbqeR1DWOkIjV2XYflzhX2HNY%2BZXrsGxZGfQ7AJXZbDb7Rbv7EE
			var randomRsvTQueryParameter = $"{RandomizerHq.RandomString(55)}";

			return String.Format(
				FormattedUrl,
				query, randomRsvPqQueryParameter, randomRsvTQueryParameter
				);
		}
	}
}
