using BeanCannon.BusinessLogic.Core.Collections;
using System;

namespace BeanCannon.BusinessLogic.Core.Randomizers.Referers
{
	public class RandomGoogleReferer : IRandomReferer
	{
		private static String[] GoogleDomainExtensions = new[] {
			".com",
			".co.jp",
			".co.uk",
			".es",
			".ca",
			".de",
			".it",
			".fr",
			".com.au",
			".com.tw",
			".nl",
			".com.br",
			".com.tr",
			".be",
			".com.gr",
			".co.in",
			".com.mx",
			".dk",
			".com.ar",
			".ch",
			".cl",
			".at",
			".co.kr",
			".ie",
			".com.co",
			".pl",
			".pt",
			".com.pk",
		};

		CircularList<int> googleDomainExtensionCircularList;

		public string FormattedUrl { get; } = "https://www.google{1}/?q={0}&rlz={2}";

		public RandomGoogleReferer()
		{
			var googleDomainExtensionsLength = GoogleDomainExtensions.Length;

			googleDomainExtensionCircularList =
				new CircularList<int>(() => new UniqueRandomizer().GenerateRandom(googleDomainExtensionsLength, 0, googleDomainExtensionsLength));
		}

		public string GetRandomElement(string query)
		{
			var value = googleDomainExtensionCircularList.Value;
			googleDomainExtensionCircularList.Next();

			// rlz=1C1GGRV_enRO754RO754
			var randomRlzQueryParameter = $"{RandomizerHq.RandomString(7)}_{RandomizerHq.RandomString(12)}";

			return String.Format(
				FormattedUrl,
				query, GoogleDomainExtensions[value], randomRlzQueryParameter
				);
		}
	}
}
