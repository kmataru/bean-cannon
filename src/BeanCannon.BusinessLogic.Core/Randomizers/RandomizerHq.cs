using BeanCannon.BusinessLogic.Core.Net;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace BeanCannon.BusinessLogic.Core.Randomizers
{
	public static class RandomizerHq
	{
		//private static readonly Random random = new Random(Guid.NewGuid().GetHashCode());
		static ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));

		private static RandomUserAgent randomUserAgent = new RandomUserAgent();
		private static RandomReferer randomReferer = new RandomReferer();

		public static string RandomString(int length = 6)
		{
			//lock (random)
			//{
			StringBuilder builder = new StringBuilder();

			char randomCharacter;
			for (int i = 0; i < length; i++)
			{
				if (random.Value.NextDouble() > 0.5)
				{
					randomCharacter = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.Value.NextDouble() + 65)));
				}
				else
				{
					randomCharacter = Convert.ToChar(Convert.ToInt32(Math.Floor(10 * random.Value.NextDouble() + 48)));
				}

				builder.Append(randomCharacter);
			}

			return builder.ToString();
			//}
		}

		public static int RandomInt(int min, int max)
		{
			//lock (random)
			//{
			return random.Value.Next(min, max);
			//}
		}

		public static string RandomUserAgent()
		{
			return randomUserAgent.GetRandomElement();
		}

		public static string RandomReferer()
		{
			return randomReferer.GetRandomElement();
		}

		public static T RandomElement<T>(T[] array)
		{
			if (array == null || array.Length < 1)
				return default(T);

			if (array.Length == 1)
				return array[0];

			//lock (random)
			//{
			return array[random.Value.Next(array.Length)];
			//}
		}

		public static Byte[] RandomByteArray(int count)
		{
			var data = new Byte[count];

			// Fill an array with 0 to (count - 1) random bytes
			int idx = 0;
			while (idx < RandomizerHq.RandomInt(0, count - 1))
			{
				data[idx++] = Convert.ToByte(RandomizerHq.RandomInt(Byte.MinValue, Byte.MaxValue));
			}

			return data;
		}

		public static FluentHeaderBuilder RandomFluentHeader(HttpMethod method, string urlPath, string host, bool appendRandomsToUrlPath = false, bool useGzip = false, int keepAliveTime = 0)
		{
			return new FluentHeaderBuilder()
				.AddMethodWithConditionalExtraPath($"{urlPath}", method, RandomizerHq.RandomString(), appendRandomsToUrlPath)
				.Add(HttpRequestHeader.Host, host)
				.Add(HttpRequestHeader.CacheControl, "no-cache")
				.Add(HttpRequestHeader.UserAgent, RandomizerHq.RandomUserAgent())
				.Add(HttpRequestHeader.Referer, RandomizerHq.RandomReferer())
				.Add(HttpRequestHeader.Accept, "*/*")
				.AddConditional(HttpRequestHeader.KeepAlive, keepAliveTime, keepAliveTime > 0)
				.AddConditional(HttpRequestHeader.Connection, "keep-alive", keepAliveTime > 0)
				//.Add(HttpRequestHeader.ContentLength, 42)
				.AddConditional(HttpRequestHeader.AcceptEncoding, "gzip,deflate", useGzip);
		}

		public static byte[] RandomHttpHeader(HttpMethod method, string urlPath, string host, bool appendRandomsToUrlPath = false, bool useGzip = false, int keepAliveTime = 0)
		{
			return RandomFluentHeader(method, urlPath, host, appendRandomsToUrlPath, useGzip, keepAliveTime)
				.BuildAsByteArray(true);
		}
	}
}
