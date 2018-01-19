using BeanCannon.BusinessLogic.Core.Attacks;
using BeanCannon.BusinessLogic.Core.Attacks.Settings;

namespace BeanCannon.BusinessLogic.Core.Factory
{
	public class AttackFactory
	{
		public IFlooder Get(IFactorySettings settings)
		{
			Logger.Log.InfoFormat(
				"Creating new {0} Flooder",
				settings.Protocol
				);

			switch (settings.Protocol)
			{
				case AttackProtocol.HTTP:
					{
						var attackSettings = new HTTPFlooderSettings(settings);

						return new HTTPFlooder(attackSettings);
					}

				case AttackProtocol.ICMP:
					{
						var attackSettings = new ICMPSettings(settings);

						return new ICMP(attackSettings);
					}

				case AttackProtocol.ReCoil:
					{
						var attackSettings = new ReCoilSettings(settings);

						return new ReCoil(attackSettings);
					}

				case AttackProtocol.SlowLOIC:
					{
						var attackSettings = new SlowLoicSettings(settings);

						return new SlowLoic(attackSettings);
					}

				case AttackProtocol.TCP:
				case AttackProtocol.UDP:
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
