/* LOIC - Low Orbit Ion Cannon
 * Released to the public domain
 * Enjoy getting v&, kids.
 */

using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using Loic.BusinessLogic.Core.Attacks.Settings;
using System.Diagnostics;

namespace BeanCannon.BusinessLogic.Core.Attacks
{
	public interface IFlooder
	{
		DosState State { get; }

		Stopwatch Clock { get; }

		AttackSettings Settings { get; }

		void Start();

		void Stop();
	}

	interface IFlooder<T> : IFlooder
		where T : AttackSettings
	{
		new T Settings { get; }
	}
}
