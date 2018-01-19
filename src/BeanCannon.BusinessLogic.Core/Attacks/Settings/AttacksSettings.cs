using System;

namespace BeanCannon.BusinessLogic.Core.Attacks.Settings
{
	public abstract class AttackSettings
	{
		/// <summary>
		/// The time between the creation of new sockets.
		/// </summary>
		public TimeSpan Delay { get; set; }

		/// <summary>
		/// The timeout between requests for the same connection.
		/// The higher the better .. but should be UNDER the READ-timeout from the server.
		/// (30 seconds seemed to be working always so far!)
		/// </summary>
		public TimeSpan Timeout { get; set; }

		/// <summary>
		/// TODO: Add description.
		/// </summary>
		public ProxyConnectionType ProxyConnectionType { get; set; }

		/// <summary>
		/// IP string of a specific server.
		/// Use this ONLY if the target does load-balancing between different IPs and you want to target a specific IP.
		/// Normally you want to provide an empty string!
		/// </summary>
		public string Ip { get; internal set; }

		/// <summary>
		/// The Port number. however so far this class only understands HTTP.
		/// </summary>
		public int Port { get; internal set; }

		public AttackSettings()
		{

		}
	}
}
