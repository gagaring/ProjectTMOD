namespace VEngine.Game
{
	public interface IGameGUIMaster
	{
		bool CloseWindow();
		int OpenedWindowCount { get; }
	}
}
