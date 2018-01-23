/* LOIC - Low Orbit Ion Cannon
 * Released to the public domain
 * Enjoy getting v&, kids.
 */

namespace BeanCannon.BusinessLogic.Core.Attacks
{
	/// <summary>
	/// Attack method/protocol.
	/// </summary>
	public enum AttackMethod
	{
		/// <summary>
		/// No (invalid) protocol.
		/// </summary>
		None = 0,

		/// <summary>
		/// Transmission Control Protocol.
		/// </summary>
		TCP = 1,

		/// <summary>
		/// User Datagram Protocol.
		/// </summary>
		UDP = 2,

		/// <summary>
		/// HyperText Transfer Protocol.
		/// </summary>
		HTTP = 3,

		/// <summary>
		/// XXX: Must be documented.
		/// </summary>
		SlowLOIC = 4,

		/// <summary>
		/// "Reverse" DDOS method.
		/// </summary>
		ReCoil = 5,

		///<summary>
		/// ICMP Protocol method
		/// </summary>
		ICMP = 6,
	}
}
