namespace BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces
{
	public interface IHttpFlooderSettings :
		IFlooderSettingsGzip,
		IFlooderSettingsHttpMethod,
		IFlooderSettingsHost,
		IFlooderSettingsUrlPath,
		IFlooderSettingsWaitReply
	{

	}
}
