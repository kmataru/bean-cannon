using BeanCannon.BusinessLogic.Core.Collections;
using System;
using System.Collections.Generic;
using FormatWith;

namespace BeanCannon.BusinessLogic.Core.Randomizers
{
	class RandomUserAgent
	{
		// READ @ http://www.useragentstring.com/pages/useragentstring.php?typ=Mobile%20Browser
		// READ @ http://www.webapps-online.com/online-tools/user-agent-strings/dv/operatingsystem51849/ios
		// READ @ https://www.keycdn.com/blog/web-crawlers/
		private static String[] FormattedUserAgents = new[] {
			// Linux based
			"Mozilla/{{MozillaVersion}} (X11; U; Linux x86_64; en-US; rv:{{RvVersion}}) Gecko/20090913 Firefox/{{RvVersion}}",

			// Windows based
			"Mozilla/{{MozillaVersion}} (Windows; U; Windows NT {{WindowsVersion}}; en; rv:{{RvVersion}}) Gecko/20090824 Firefox/{{RvVersion}} (.NET CLR 3.5.30729)",
			"Mozilla/{{MozillaVersion}} (Windows; U; Windows NT {{WindowsVersion}}; en-US; rv:{{RvVersion}}) Gecko/20090824 Firefox/{{RvVersion}} (.NET CLR 3.5.30729)",
			"Mozilla/{{MozillaVersion}} (Windows; U; Windows NT {{WindowsVersion}}; en-US; rv:{{RvVersion}}) Gecko/20090718 Firefox/{{RvVersion}}",
			"Mozilla/{{MozillaVersion}} (Windows; U; Windows NT {{WindowsVersion}}; en-US) AppleWebKit/{{SafariVersion}} (KHTML, like Gecko) Chrome/{{RvVersion}} Safari/{{SafariVersion}}",
			"Mozilla/{{MozillaVersion}} (compatible; MSIE {{IeVersion}}; Windows NT {{WindowsVersion}}; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; InfoPath.2)",
			"Mozilla/{{MozillaVersion}} (compatible; MSIE {{IeVersion}}; Windows NT {{WindowsVersion}}; Trident/4.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 1.1.4322; .NET CLR 3.5.30729; .NET CLR 3.0.30729)",
			"Mozilla/{{MozillaVersion}} (compatible; MSIE {{IeVersion}}; Windows NT {{WindowsVersion}}; Win64; x64; Trident/4.0)",
			"Mozilla/{{MozillaVersion}} (compatible; MSIE {{IeVersion}}; Windows NT {{WindowsVersion}}; Trident/4.0; SV1; .NET CLR 2.0.50727; InfoPath.2)",
			"Mozilla/{{MozillaVersion}} (Windows; U; MSIE {{IeVersion}}; Windows NT {{WindowsVersion}}; en-US)",
			"Mozilla/{{MozillaVersion}} (compatible; MSIE {{IeVersion}}; Windows XP)",
			"Opera/{{OperaVersion}}.0 (Windows NT {{WindowsVersion}}; U; ru) Presto/{{RvVersion}} Version/{{RvVersion}}",

			// Android Webkit Browser
			"Mozilla/{{MozillaVersion}} (Linux; U; Android {{AndroidVersion}}; en-US; LG-L160L Build/IML74K) AppleWebkit/{{SafariVersion}} (KHTML, like Gecko) Version/{{GenericVersion}} Mobile Safari/{{SafariVersion}}",

			// BlackBerry
			"Mozilla/{{MozillaVersion}} (BlackBerry; U; BlackBerry {{BlackBerryVersion}}; en) AppleWebKit/{{SafariVersion}} (KHTML, like Gecko) Version/{{GenericVersion}} Mobile Safari/{{SafariVersion}}",
			
			// Opera Mini
			"Opera/{{OperaVersion}}.0 (J2ME/MIDP; Opera Mini/{{OperaVersion}}.0 (S60; SymbOS; Opera Mobi/23.348; U; en) Presto/2.5.25 Version/{{GenericVersion}}",
			
			// iOS
			"Mozilla/{{MozillaVersion}} (iPad; CPU OS {{IOsVersion}} like Mac OS X) AppleWebKit/{{SafariVersion}} (KHTML, like Gecko) CriOS/30.0.1599.12 Mobile/11A465 Safari/{{SafariVersion}}",

			// Google Bots
			"Mozilla/{{MozillaVersion}} (compatible; {{GoogleBotName}}/{{BotVersion}}; +http://www.google.com/bot.html)",
			"SAMSUNG-SGH-E250/1.0 Profile/MIDP-2.0 Configuration/CLDC-1.1 UP.Browser/6.2.3.3.c.1.101 (GUI) MMP/2.0 (compatible; Googlebot-Mobile/{{BotVersion}}; +http://www.google.com/bot.html)",
			"Mozilla/{{MozillaVersion}} (Linux; Android {{AndroidVersion}}; Nexus 5X Build/MMB29P) AppleWebKit/{{SafariVersion}} (KHTML, like Gecko) Chrome/{{RvVersion}} Mobile Safari/{{SafariVersion}} (compatible; Googlebot/{{BotVersion}}; +http://www.google.com/bot.html)",
			"Google (+https://developers.google.com/+/web/snippet/)",

			// Bing Bot
			"Mozilla/{{MozillaVersion}} (compatible; Bingbot/{{BotVersion}}; +http://www.bing.com/bingbot.htm)",

			// Slurp Bot
			"Mozilla/{{MozillaVersion}} (compatible; Yahoo! Slurp; http://help.yahoo.com/help/us/ysearch/slurp)",

			// DuckDuck Bot
			"DuckDuckBot/{{BotVersion}}; (+http://duckduckgo.com/duckduckbot.html)",

			// Baidu Spiders
			"Mozilla/{{MozillaVersion}} (compatible; {{BaiduSpiderName}}/{{BotVersion}}; +http://www.baidu.com/search/spider.html)",

			// Yandex Bot
			"Mozilla/{{MozillaVersion}} (compatible; YandexBot/{{BotVersion}}; +http://yandex.com/bots)",

			// Sogou Spider
			"Sogou Pic Spider/{{BotVersion}}( http://www.sogou.com/docs/help/webmasters.htm#07)",
			"Sogou head spider/{{BotVersion}}( http://www.sogou.com/docs/help/webmasters.htm#07)",
			"Sogou web spider/{{BotVersion}}(+http://www.sogou.com/docs/help/webmasters.htm#07)",
			"Sogou Orion spider/{{BotVersion}}( http://www.sogou.com/docs/help/webmasters.htm#07)",
			"Sogou-Test-Spider/{{BotVersion}} (compatible; MSIE {{IeVersion}}; Windows NT {{WindowsVersion}})",

			// Exa Bot
			"Mozilla/{{MozillaVersion}} (compatible; Konqueror/{{BotVersion}}; Linux) KHTML/3.5.5 (like Gecko) (Exabot-Thumbnails)",
			"Mozilla/{{MozillaVersion}} (compatible; Exabot/{{BotVersion}}; +http://www.exabot.com/go/robot)",

			// Facebook External Hit
			"{{FacebookBotName}}/{{FacebookBotVersion}} (+http://www.facebook.com/externalhit_uatext.php)",

			// Alexa Crawler
			"ia_archiver (+http://www.alexa.com/site/help/webmasters; crawler@alexa.com)",

			// Other Bots
			"http.rb/2.2.2 (Mastodon/{{BotVersion}}; +https://example-masto-instance.org/)",
			"Mozilla/{{MozillaVersion}} (compatible; DnyzBot/{{BotVersion}})",
			"Mozilla/{{MozillaVersion}} (iPhone; CPU iPhone OS 8_3 like Mac OS X) AppleWebKit/{{SafariVersion}} (KHTML, like Gecko) Version/8.0 Mobile/12F70 Safari/{{SafariVersion}} (compatible; Laserlikebot/{{BotVersion}})",
			"Mozilla/{{MozillaVersion}} (Windows; U; Windows NT 5.1; en; rv:1.9.0.13) Gecko/2009073022 Firefox/{{RvVersion}} (.NET CLR 3.5.30729) SurveyBot/{{BotVersion}} (DomainTools)",
			"Mozilla/{{MozillaVersion}} (compatible; epicbot; +http://www.epictions.com/epicbot)",
			"Mozilla/{{MozillaVersion}} (compatible; TinEye-bot/{{BotVersion}}; +http://www.tineye.com/crawler.html)",
			"Pinterest/{{BotVersion}} (+http://www.pinterest.com/bot.html)",
			"Mozilla/{{MozillaVersion}} (compatible; MojeekBot/{{BotVersion}}; http://www.mojeek.com/bot.html)",
		};

		private static readonly String[] WindowsVersions = { "5.2", "6.0", "6.1", "6.2", "6.3", "10.0" };
		private static readonly String[] IeVersions = { "6.1", "7.0", "8.0" };

		private static readonly String[] BaiduSpiderNames = {
			"Baiduspider",
			"Baiduspider-image",
			"Baiduspider-video",
			"Baiduspider-news",
			"Baiduspider-favo",
			"Baiduspider-cpro",
			"Baiduspider-ads",
		};

		private static readonly String[] FacebookBotNames = {
			"facebot",
			"facebookexternalhit",
		};

		private static readonly String[] GoogleBotNames = {
			"Googlebot",
			"Googlebot-News",
			"Googlebot-Image/1.0",
			"Googlebot-Video/1.0",
			"Mediapartners-Google",
			"AdsBot-Google",
			"AdsBot-Google-Mobile-Apps",
		};

		CircularList<int> formattedUserAgentsCircularList;
		Dictionary<String, Func<object>> templateFields;

		public RandomUserAgent()
		{
			var formattedUserAgentsLength = FormattedUserAgents.Length;

			formattedUserAgentsCircularList =
				new CircularList<int>(() => new UniqueRandomizer().GenerateRandom(formattedUserAgentsLength, 0, formattedUserAgentsLength));

			templateFields = new Dictionary<String, Func<object>>();

			templateFields.Add("AndroidVersion", () => $"{RandomizerHq.RandomInt(2, 6)}.{RandomizerHq.RandomInt(0, 4)}.{RandomizerHq.RandomInt(0, 5)}");
			templateFields.Add("BaiduSpiderName", () => BaiduSpiderNames[RandomizerHq.RandomInt(0, BaiduSpiderNames.Length)]);
			templateFields.Add("BotVersion", () => { var value = RandomizerHq.RandomInt(200, 500).ToString(); return $"{value[0]}.{value[1]}.{value[2]}"; });
			templateFields.Add("BlackBerryVersion", () => 9000 + 100 * RandomizerHq.RandomInt(1, 9) + 10 * RandomizerHq.RandomInt(1, 5));
			templateFields.Add("FacebookBotName", () => FacebookBotNames[RandomizerHq.RandomInt(0, FacebookBotNames.Length)]);
			templateFields.Add("FacebookBotVersion", () => RandomizerHq.RandomInt(10, 21).ToString("0.0"));
			templateFields.Add("GenericVersion", () => $"{RandomizerHq.RandomInt(4, 7)}.{RandomizerHq.RandomInt(0, 6)}.{RandomizerHq.RandomInt(2, 7)}.{RandomizerHq.RandomInt(100, 666)}");
			templateFields.Add("GoogleBotName", () => GoogleBotNames[RandomizerHq.RandomInt(0, GoogleBotNames.Length)]);
			templateFields.Add("IeVersion", () => IeVersions[RandomizerHq.RandomInt(0, IeVersions.Length)]);
			templateFields.Add("IOsVersion", () => $"{RandomizerHq.RandomInt(3, 7)}_{RandomizerHq.RandomInt(0, 4)}_{RandomizerHq.RandomInt(0, 5)}");
			templateFields.Add("MozillaVersion", () => (RandomizerHq.RandomInt(30, 50) / 10).ToString("0.0"));
			templateFields.Add("OperaVersion", () => RandomizerHq.RandomInt(5, 10));
			templateFields.Add("RvVersion", () => $"{RandomizerHq.RandomInt(36, 47)}.0");
			templateFields.Add("SafariVersion", () => $"{RandomizerHq.RandomInt(333, 999)}.{RandomizerHq.RandomInt(1, 69)}");
			templateFields.Add("WindowsVersion", () => WindowsVersions[RandomizerHq.RandomInt(0, WindowsVersions.Length)]);
		}

		public string GetRandomElement()
		{
			var value = formattedUserAgentsCircularList.Value;
			formattedUserAgentsCircularList.Next();

			var formattedAgent = FormattedUserAgents[value];
			var processedFormattedAgent = formattedAgent;

			return formattedAgent.FormatWith(templateFields as IDictionary<string, object>);
		}
	}
}
