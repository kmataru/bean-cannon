using System.Net.Http;

namespace BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces
{
	public interface IFlooderSettingsGzip
	{
		/// <summary>
		/// Turns on the gzip / deflate header to check for: CVE-2009-1891.
		/// </summary>
		bool AllowGzip { get; }
	}

	public interface IFlooderSettingsHttpMethod
	{
		/// <summary>
		/// Represents an HTTP protocol method.
		/// </summary>
		HttpMethod HttpRequestMethod { get; }
	}

	public interface IFlooderSettingsHost
	{
		/// <summary>
		/// DNS string of the target.
		/// </summary>
		string Host { get; }
	}

	public interface IFlooderSettingsRandomMessage
	{
		bool UseRandomMessage { get; }
	}

	public interface IFlooderSettingsSocketsPerThread
	{
		/// <summary>
		/// The amount of sockets for this object.
		/// </summary>
		int SocketsPerThread { get; }
	}

	public interface IFlooderSettingsUrlPath
	{
		/// <summary>
		/// The path to the targeted site / document. (remember: the file has to be at least around 24KB!).
		/// </summary>
		string UrlPath { get; }

		/// <summary>
		/// Adds a random string to the <seealso cref="UrlPath"/>.
		/// </summary>
		bool UseRandomPath { get; }
	}

	public interface IFlooderSettingsWaitReply
	{
		/// <summary>
		/// Wait for the first packet.
		/// </summary>
		bool WaitReply { get; }
	}
}
