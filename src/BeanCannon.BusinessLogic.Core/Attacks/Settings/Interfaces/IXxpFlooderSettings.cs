namespace BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces
{
	public interface IXxpFlooderSettings :
		IFlooderSettingsRandomMessage,
		IFlooderSettingsWaitReply
	{
		AttackProtocol Protocol { get; }

		string StreamData { get; }
	}
}
