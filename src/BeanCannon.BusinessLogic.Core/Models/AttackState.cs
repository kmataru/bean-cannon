using Loic.BusinessLogic.Core.Attacks.Settings;

namespace BeanCannon.BusinessLogic.Core.Models
{
	public class AttackState
	{
		public int Idle { get; set; }

		public int Connecting { get; set; }

		public int Requesting { get; set; }

		public int Downloading { get; set; }

		public int Downloaded { get; set; }

		public int Requested { get; set; }

		public int Failed { get; set; }
	}
}
