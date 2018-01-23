namespace BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces
{
	public interface IXxpFlooderSettings :
		IFlooderSettingsRandomMessage,
		IFlooderSettingsWaitReply
	{
		AttackMethod Protocol { get; }

		string StreamData { get; }
	}
}
