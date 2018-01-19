using CsQuery.ExtensionMethods;
using BeanCannon.BusinessLogic.Core.Collections;
using System;
using System.Collections.Generic;

namespace BeanCannon.BusinessLogic.Core.Randomizers
{
	class RandomUserAgent
	{
		// TODO: READ @ http://www.useragentstring.com/pages/useragentstring.php?typ=Mobile%20Browser
		// TODO: READ @ http://www.webapps-online.com/online-tools/user-agent-strings/dv/operatingsystem51849/ios
		// TODO: READ @ https://www.keycdn.com/blog/web-crawlers/
		private static String[] FormattedUserAgents = new[] {
			// Linux based
			"Mozilla/{{MozillaVersion}}.0 (X11; U; Linux x86_64; en-US; rv:{{RvVersion}}.0) Gecko/20090913 Firefox/{{RvVersion}}.0",

			// Windows based
			"Mozilla/{{MozillaVersion}}.0 (Windows; U; Windows NT {{WindowsVersion}}; en; rv:{{RvVersion}}.0) Gecko/20090824 Firefox/{{RvVersion}}.0 (.NET CLR 3.5.30729)",
			"Mozilla/{{MozillaVersion}}.0 (Windows; U; Windows NT {{WindowsVersion}}; en-US; rv:{{RvVersion}}.0) Gecko/20090824 Firefox/{{RvVersion}}.0 (.NET CLR 3.5.30729)",
			"Mozilla/{{MozillaVersion}}.0 (Windows; U; Windows NT {{WindowsVersion}}; en-US; rv:{{RvVersion}}.0) Gecko/20090718 Firefox/{{RvVersion}}.0",
			"Mozilla/{{MozillaVersion}}.0 (Windows; U; Windows NT {{WindowsVersion}}; en-US) AppleWebKit/{{SafariVersion}} (KHTML, like Gecko) Chrome/{{RvVersion}}.0 Safari/{{SafariVersion}}",
			"Mozilla/{{MozillaVersion}}.0 (compatible; MSIE {{IeVersion}}; Windows NT {{WindowsVersion}}; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; InfoPath.2)",
			"Mozilla/{{MozillaVersion}}.0 (compatible; MSIE {{IeVersion}}; Windows NT {{WindowsVersion}}; Trident/4.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 1.1.4322; .NET CLR 3.5.30729; .NET CLR 3.0.30729)",
			"Mozilla/{{MozillaVersion}}.0 (compatible; MSIE {{IeVersion}}; Windows NT {{WindowsVersion}}; Win64; x64; Trident/4.0)",
			"Mozilla/{{MozillaVersion}}.0 (compatible; MSIE {{IeVersion}}; Windows NT {{WindowsVersion}}; Trident/4.0; SV1; .NET CLR 2.0.50727; InfoPath.2)",
			"Mozilla/{{MozillaVersion}}.0 (Windows; U; MSIE {{IeVersion}}; Windows NT {{WindowsVersion}}; en-US)",
			"Mozilla/{{MozillaVersion}}.0 (compatible; MSIE {{IeVersion}}; Windows XP)",
			"Opera/{{OperaVersion}}.0 (Windows NT {{WindowsVersion}}; U; ru) Presto/{{RvVersion}}.0 Version/{{RvVersion}}.0",

			// Android Webkit Browser
			"Mozilla/{{MozillaVersion}}.0 (Linux; U; Android {{AndroidVersion}}; en-US; LG-L160L Build/IML74K) AppleWebkit/{{SafariVersion}} (KHTML, like Gecko) Version/{{GenericVersion}} Mobile Safari/{{SafariVersion}}",

			// BlackBerry
			"Mozilla/{{MozillaVersion}}.0 (BlackBerry; U; BlackBerry {{BlackBerryVersion}}; en) AppleWebKit/{{SafariVersion}} (KHTML, like Gecko) Version/{{GenericVersion}} Mobile Safari/{{SafariVersion}}",
			
			// Opera Mini
			"Opera/{{OperaVersion}}.0 (J2ME/MIDP; Opera Mini/{{OperaVersion}}.0 (S60; SymbOS; Opera Mobi/23.348; U; en) Presto/2.5.25 Version/{{GenericVersion}}",
			
			// iOS
			"Mozilla/{{MozillaVersion}}.0 (iPad; CPU OS {{IOsVersion}} like Mac OS X) AppleWebKit/{{SafariVersion}} (KHTML, like Gecko) CriOS/30.0.1599.12 Mobile/11A465 Safari/{{SafariVersion}}",
		};

		private static readonly String[] WindowsVersions = { "5.2", "6.0", "6.1", "6.2", "6.3", "10.0" };
		private static readonly String[] IeVersions = { "6.1", "7.0", "8.0" };

		CircularList<int> formattedUserAgentsCircularList;
		Dictionary<String, Func<object>> templateFields;

		public RandomUserAgent()
		{
			var formattedUserAgentsLength = FormattedUserAgents.Length;

			formattedUserAgentsCircularList =
				new CircularList<int>(() => new UniqueRandomizer().GenerateRandom(formattedUserAgentsLength, 0, formattedUserAgentsLength));

			templateFields = new Dictionary<String, Func<object>>();

			templateFields.Add("AndroidVersion", () => $"{RandomizerHq.RandomInt(2, 6)}.{RandomizerHq.RandomInt(0, 4)}.{RandomizerHq.RandomInt(0, 5)}");
			templateFields.Add("BlackBerryVersion", () => 9000 + 100 * RandomizerHq.RandomInt(1, 9) + 10 * RandomizerHq.RandomInt(1, 5));
			templateFields.Add("GenericVersion", () => $"{RandomizerHq.RandomInt(4, 7)}.{RandomizerHq.RandomInt(0, 6)}.{RandomizerHq.RandomInt(2, 7)}.{RandomizerHq.RandomInt(100, 666)}");
			templateFields.Add("IeVersion", () => IeVersions[RandomizerHq.RandomInt(0, IeVersions.Length)]);
			templateFields.Add("IOsVersion", () => $"{RandomizerHq.RandomInt(3, 7)}_{RandomizerHq.RandomInt(0, 4)}_{RandomizerHq.RandomInt(0, 5)}");
			templateFields.Add("MozillaVersion", () => RandomizerHq.RandomInt(3, 5));
			templateFields.Add("OperaVersion", () => RandomizerHq.RandomInt(5, 10));
			templateFields.Add("RvVersion", () => RandomizerHq.RandomInt(36, 47));
			templateFields.Add("SafariVersion", () => $"{RandomizerHq.RandomInt(333, 999)}.{RandomizerHq.RandomInt(1, 69)}");
			templateFields.Add("WindowsVersion", () => WindowsVersions[RandomizerHq.RandomInt(0, WindowsVersions.Length)]);
		}

		public string GetRandomElement()
		{
			var value = formattedUserAgentsCircularList.Value;
			formattedUserAgentsCircularList.Next();

			var formattedAgent = FormattedUserAgents[value];
			var processedFormattedAgent = formattedAgent;

			SuperXML.Compiler compiler = new SuperXML.Compiler();

			templateFields.ForEach(w =>
			{
				if (formattedAgent.Contains(w.Key))
				{
					compiler.AddKey(w.Key, w.Value());
				}
			});

			return compiler.CompileString(formattedAgent);
		}
	}
}
