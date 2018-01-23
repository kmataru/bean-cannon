/* LOIC - Low Orbit Ion Cannon
 * Released to the public domain
 * Enjoy getting v&, kids.
 */

using System;

namespace BeanCannon.BusinessLogic.Core
{
	public enum RequestStatus
	{
		Ready,
		Aquiring,
		Connecting,
		Requesting,
		Downloading,
		Completed,
		Failed
	};
}
