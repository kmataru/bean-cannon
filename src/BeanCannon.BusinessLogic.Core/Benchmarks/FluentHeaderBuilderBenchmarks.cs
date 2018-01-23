using BenchmarkDotNet.Attributes;
using BeanCannon.BusinessLogic.Core.Net;
using BeanCannon.BusinessLogic.Core.Randomizers;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BeanCannon.BusinessLogic.Core.Benchmarks
{
	[Config("columns=AllStatistics")]
	public class FluentHeaderBuilderBenchmarks
	{
		HttpMethod method;
		String subsite;
		String host;
		bool subsite_random;
		int keep_alive;
		bool gzip;

		public FluentHeaderBuilderBenchmarks()
		{
			method = HttpMethod.Get;
			subsite = "/";
			host = "www.example.com";
			subsite_random = false;
			keep_alive = 15;
			gzip = false;
		}

		[Benchmark]
		public byte[] WithFluentHeaderBuilder()
		{
			return new FluentHeaderBuilder()
				.AddMethodWithConditionalExtraPath($"{subsite}", method, RandomizerHq.RandomString(), subsite_random)
				.Add(HttpRequestHeader.Host, host)
				.Add(HttpRequestHeader.CacheControl, "no-cache")
				.Add(HttpRequestHeader.UserAgent, RandomizerHq.RandomUserAgent())
				.Add(HttpRequestHeader.Accept, "*/*")
				.AddConditional(HttpRequestHeader.KeepAlive, keep_alive, keep_alive > 0)
				.AddConditional(HttpRequestHeader.Connection, "keep-alive", keep_alive > 0)
				//.Add(HttpRequestHeader.ContentLength, 42)
				.AddConditional(HttpRequestHeader.AcceptEncoding, "gzip,deflate", gzip)
				.BuildAsByteArray();
		}

		[Benchmark]
		public byte[] WithoutFluentHeaderBuilder()
		{
			string header = String.Format(
				"{0} {1}{2} HTTP/1.1{7}Host: {3}{7}Cache-Control: no-cache{7}User-Agent: {4}{7}Accept: */*{7}{5}{6}{7}",
				method.Method,
				subsite,
				(subsite_random ? RandomizerHq.RandomString() : ""),
				host,
				RandomizerHq.RandomUserAgent(),
				(gzip ? "Accept-Encoding: gzip, deflate\r\n" : ""),
				(keep_alive > 0 ? String.Format("Keep-Alive: {0}\r\nConnection: keep-alive\r\n", keep_alive) : ""),
				"\r\n"
			);

			return Encoding.ASCII.GetBytes(header);
		}
	}
}
