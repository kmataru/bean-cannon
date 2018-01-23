using BeanCannon.BusinessLogic.Core.Attacks;
using BeanCannon.BusinessLogic.Core.Attacks.Settings;

namespace BeanCannon.BusinessLogic.Core.Factory
{
	public class AttackFactory
	{
		public IFlooder Get(IApplicationSettings settings)
		{
			Logger.Log.InfoFormat(
				"Creating new {0} Flooder",
				settings.Protocol
				);

			switch (settings.Protocol)
			{
				case AttackMethod.HTTP:
					{
						var attackSettings = new HTTPFlooderSettings(settings);

						return new HTTPFlooder(attackSettings);
					}

				case AttackMethod.ICMP:
					{
						var attackSettings = new ICMPSettings(settings);

						return new ICMP(attackSettings);
					}

				case AttackMethod.ReCoil:
					{
						var attackSettings = new ReCoilSettings(settings);

						return new ReCoil(attackSettings);
					}

				case AttackMethod.SlowLOIC:
					{
						var attackSettings = new SlowLoicSettings(settings);

						return new SlowLoic(attackSettings);
					}

				case AttackMethod.TCP:
				case AttackMethod.UDP:
					{
						var attackSettings = new XXPFlooderSettings(settings);

						return new XXPFlooder(attackSettings);
					}

				default:
					return null;
			}
		}
	}
}
