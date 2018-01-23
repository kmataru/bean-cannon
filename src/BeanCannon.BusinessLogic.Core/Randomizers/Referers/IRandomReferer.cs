namespace BeanCannon.BusinessLogic.Core.Randomizers.Referers
{
	public interface IRandomReferer
	{
		string FormattedUrl { get; }

		string GetRandomElement(string query);
	}
}
