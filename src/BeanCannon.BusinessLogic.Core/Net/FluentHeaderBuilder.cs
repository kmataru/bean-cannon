using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeanCannon.BusinessLogic.Core.Net
{
	internal static class HttpKnownHeaderNames
	{
		public const string CacheControl = "Cache-Control";
		public const string Connection = "Connection";
		public const string Date = "Date";
		public const string KeepAlive = "Keep-Alive";
		public const string Pragma = "Pragma";
		//public const string ProxyConnection = "Proxy-Connection";
		public const string Trailer = "Trailer";
		public const string TransferEncoding = "Transfer-Encoding";
		public const string Upgrade = "Upgrade";
		public const string Via = "Via";
		public const string Warning = "Warning";
		public const string ContentLength = "Content-Length";
		public const string ContentType = "Content-Type";
		//public const string ContentDisposition = "Content-Disposition";
		public const string ContentEncoding = "Content-Encoding";
		public const string ContentLanguage = "Content-Language";
		public const string ContentLocation = "Content-Location";
		public const string ContentRange = "Content-Range";
		public const string Expires = "Expires";
		public const string LastModified = "Last-Modified";
		//public const string Age = "Age";
		//public const string Location = "Location";
		//public const string ProxyAuthenticate = "Proxy-Authenticate";
		//public const string RetryAfter = "Retry-After";
		//public const string Server = "Server";
		//public const string SetCookie = "Set-Cookie";
		//public const string SetCookie2 = "Set-Cookie2";
		//public const string Vary = "Vary";
		//public const string WWWAuthenticate = "WWW-Authenticate";
		public const string Accept = "Accept";
		public const string AcceptCharset = "Accept-Charset";
		public const string AcceptEncoding = "Accept-Encoding";
		public const string AcceptLanguage = "Accept-Language";
		public const string Authorization = "Authorization";
		public const string Cookie = "Cookie";
		//public const string Cookie2 = "Cookie2";
		public const string Expect = "Expect";
		public const string From = "From";
		public const string Host = "Host";
		public const string IfMatch = "If-Match";
		public const string IfModifiedSince = "If-Modified-Since";
		public const string IfNoneMatch = "If-None-Match";
		public const string IfRange = "If-Range";
		public const string IfUnmodifiedSince = "If-Unmodified-Since";
		public const string MaxForwards = "Max-Forwards";
		public const string ProxyAuthorization = "Proxy-Authorization";
		public const string Referer = "Referer";
		public const string Range = "Range";
		public const string UserAgent = "User-Agent";
		public const string ContentMD5 = "Content-MD5";
		//public const string ETag = "ETag";
		public const string TE = "TE";
		public const string Allow = "Allow";
		//public const string AcceptRanges = "Accept-Ranges";
		//public const string P3P = "P3P";
		//public const string XPoweredBy = "X-Powered-By";
		//public const string XAspNetVersion = "X-AspNet-Version";
		//public const string SecWebSocketKey = "Sec-WebSocket-Key";
		//public const string SecWebSocketExtensions = "Sec-WebSocket-Extensions";
		//public const string SecWebSocketAccept = "Sec-WebSocket-Accept";
		//public const string Origin = "Origin";
		//public const string SecWebSocketProtocol = "Sec-WebSocket-Protocol";
		//public const string SecWebSocketVersion = "Sec-WebSocket-Version";
	}

	public class FluentHeaderBuilder
	{
		internal static Dictionary<HttpRequestHeader, String> Mapping = new Dictionary<HttpRequestHeader, String>() {
			{ HttpRequestHeader.CacheControl, HttpKnownHeaderNames.CacheControl },
			{ HttpRequestHeader.Connection, HttpKnownHeaderNames.Connection },
			{ HttpRequestHeader.Date, HttpKnownHeaderNames.Date },
			{ HttpRequestHeader.KeepAlive, HttpKnownHeaderNames.KeepAlive },
			{ HttpRequestHeader.Pragma, HttpKnownHeaderNames.Pragma },
			{ HttpRequestHeader.Trailer, HttpKnownHeaderNames.Trailer },
			{ HttpRequestHeader.TransferEncoding, HttpKnownHeaderNames.TransferEncoding },
			{ HttpRequestHeader.Upgrade, HttpKnownHeaderNames.Upgrade },
			{ HttpRequestHeader.Via, HttpKnownHeaderNames.Via },
			{ HttpRequestHeader.Warning, HttpKnownHeaderNames.Warning },
			{ HttpRequestHeader.Allow, HttpKnownHeaderNames.Allow },
			{ HttpRequestHeader.ContentLength, HttpKnownHeaderNames.ContentLength },
			{ HttpRequestHeader.ContentType, HttpKnownHeaderNames.ContentType },
			{ HttpRequestHeader.ContentEncoding, HttpKnownHeaderNames.ContentEncoding },
			{ HttpRequestHeader.ContentLanguage, HttpKnownHeaderNames.ContentLanguage },
			{ HttpRequestHeader.ContentLocation, HttpKnownHeaderNames.ContentLocation },
			{ HttpRequestHeader.ContentMd5, HttpKnownHeaderNames.ContentMD5 },
			{ HttpRequestHeader.ContentRange, HttpKnownHeaderNames.ContentRange },
			{ HttpRequestHeader.Expires, HttpKnownHeaderNames.Expires },
			{ HttpRequestHeader.LastModified, HttpKnownHeaderNames.LastModified },
			{ HttpRequestHeader.Accept, HttpKnownHeaderNames.Accept },
			{ HttpRequestHeader.AcceptCharset, HttpKnownHeaderNames.AcceptCharset },
			{ HttpRequestHeader.AcceptEncoding, HttpKnownHeaderNames.AcceptEncoding },
			{ HttpRequestHeader.AcceptLanguage, HttpKnownHeaderNames.AcceptLanguage },
			{ HttpRequestHeader.Authorization, HttpKnownHeaderNames.Authorization },
			{ HttpRequestHeader.Cookie, HttpKnownHeaderNames.Cookie },
			{ HttpRequestHeader.Expect, HttpKnownHeaderNames.Expect },
			{ HttpRequestHeader.From, HttpKnownHeaderNames.From },
			{ HttpRequestHeader.Host, HttpKnownHeaderNames.Host },
			{ HttpRequestHeader.IfMatch, HttpKnownHeaderNames.IfMatch },
			{ HttpRequestHeader.IfModifiedSince, HttpKnownHeaderNames.IfModifiedSince },
			{ HttpRequestHeader.IfNoneMatch, HttpKnownHeaderNames.IfNoneMatch },
			{ HttpRequestHeader.IfRange, HttpKnownHeaderNames.IfRange },
			{ HttpRequestHeader.IfUnmodifiedSince, HttpKnownHeaderNames.IfUnmodifiedSince },
			{ HttpRequestHeader.MaxForwards, HttpKnownHeaderNames.MaxForwards },
			{ HttpRequestHeader.ProxyAuthorization, HttpKnownHeaderNames.ProxyAuthorization },
			{ HttpRequestHeader.Referer, HttpKnownHeaderNames.Referer },
			{ HttpRequestHeader.Range, HttpKnownHeaderNames.Range },
			{ HttpRequestHeader.Te, HttpKnownHeaderNames.TE },
			//{ HttpRequestHeader.Translate, HttpKnownHeaderNames.Translate },
			{ HttpRequestHeader.UserAgent, HttpKnownHeaderNames.UserAgent },
		};

		internal StringBuilder header = new StringBuilder();

		private const string HeaderFormat = "{0}: {1}{2}";

		public FluentHeaderBuilder AddMethod(String path, HttpMethod method)
		{
			this.header.Append($"{method.Method} {path} HTTP/1.1{Environment.NewLine}");
			return this;
		}

		public FluentHeaderBuilder AddMethodWithConditionalExtraPath(String path, HttpMethod method, String extraPath, bool condition)
		{
			var processedExtraPath = (condition ? extraPath : String.Empty);
			if (!path.EndsWith("/"))
			{
				processedExtraPath = '/' + processedExtraPath;
			}

			this.header.Append($"{method.Method} {path}{processedExtraPath} HTTP/1.1{Environment.NewLine}");
			return this;
		}

		public FluentHeaderBuilder Add(HttpRequestHeader header, String value)
		{
			this.header.AppendFormat(HeaderFormat, FluentHeaderBuilder.Mapping[header], value, Environment.NewLine);
			return this;
		}

		public FluentHeaderBuilder Add(HttpRequestHeader header, int value)
		{
			this.header.AppendFormat(HeaderFormat, FluentHeaderBuilder.Mapping[header], value, Environment.NewLine);
			return this;
		}

		public FluentHeaderBuilder AddCustom(String header, String value)
		{
			this.header.AppendFormat(HeaderFormat, header, value, Environment.NewLine);
			return this;
		}

		public FluentHeaderBuilder AddConditional(HttpRequestHeader header, String value, bool condition)
		{
			if (condition)
			{
				this.header.AppendFormat(HeaderFormat, FluentHeaderBuilder.Mapping[header], value, Environment.NewLine);
			}

			return this;
		}

		public FluentHeaderBuilder AddConditional(HttpRequestHeader header, int value, bool condition)
		{
			if (condition)
			{
				this.header.AppendFormat(HeaderFormat, FluentHeaderBuilder.Mapping[header], value, Environment.NewLine);
			}

			return this;
		}

		public byte[] BuildAsByteArray(bool appendNewLine = false)
		{
			if (appendNewLine)
			{
				this.header.Append(Environment.NewLine);
			}

			return Encoding.ASCII.GetBytes(this.ToString());
		}

		public override string ToString()
		{
			return this.header.ToString();
		}
	}
}
