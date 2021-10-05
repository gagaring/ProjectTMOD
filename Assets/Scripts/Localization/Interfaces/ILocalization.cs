namespace VEngine.Localization
{
	public interface ILocalization
	{
		string LoadStr(string key);
		void RefreshText();
	}
}
