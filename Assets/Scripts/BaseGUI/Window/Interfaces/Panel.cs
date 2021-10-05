namespace VEngine.GUI
{
	public interface IPanel
	{
		string Name { get; }

		void Open(bool open);
		void Open();
		void Close();
		void Toggle();
	}
}