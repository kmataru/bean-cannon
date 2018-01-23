namespace BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces
{
	public interface ISlowLoicSettings :
		IFlooderSettingsHttpMethod,
		IFlooderSettingsHost,
		IFlooderSettingsSocketsPerThread,
		IFlooderSettingsUrlPath,
		IFlooderSettingsGzip
	{
		/// <summary>
		/// Randomizes the sent header for every request on the same socket.
		/// (however all sockets send the same partial header during the same cyclus).
		/// </summary>
		bool UseRandomCommands { get; }
	}
}
