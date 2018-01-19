using Newtonsoft.Json;
using Org.Mentalis.Network.ProxySocket;
using System.Collections.Generic;
using System.Net.Sockets;

namespace BeanCannon.BusinessLogic.Core.Models
{
	public partial class SpinProxiesRootResponse
	{
		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("data")]
		public SpinProxiesData Data { get; set; }

		[JsonProperty("request_id")]
		public object RequestId { get; set; }
	}

	public partial class SpinProxiesData
	{
		[JsonProperty("proxies")]
		public List<ProxyDatum> Proxies { get; set; }
	}

	public partial class ProxyDatum
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("speed")]
		public string Speed { get; set; }

		[JsonProperty("ip")]
		public string Ip { get; set; }

		[JsonProperty("port")]
		public int Port { get; set; }

		[JsonProperty("country_code")]
		public string CountryCode { get; set; }

		[JsonProperty("protocol")]
		public string Protocol { get; set; }

		public Dictionary<AddressFamily, Dictionary<SocketType, Dictionary<ProtocolType, Dictionary<ProxyTypes, double>>>> Tests { get; set; }
	}

	public partial class SpinProxiesRootResponse
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Formatting = Formatting.Indented,
		};

		public static SpinProxiesRootResponse FromJson(string json) => JsonConvert.DeserializeObject<SpinProxiesRootResponse>(json, Settings);
		public string ToJson() => JsonConvert.SerializeObject(this, Settings);
	}
}
