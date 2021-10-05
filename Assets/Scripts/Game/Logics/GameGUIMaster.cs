using VEngine.GUI;
using VEngine.SO.Events;

namespace VEngine.Game
{
	public class GameGUIMaster : IGameGUIMaster
	{
		private readonly IData _data;

		public GameGUIMaster(IData data) => _data = data;

		public int OpenedWindowCount => _data.StackReference.OpenWindowCount;

		public bool CloseWindow()
		{
			if (_data.StackReference.IsEmpty)
				return false;
			_data.CloseTopWindowGameEvent.Raise();
			return true;

		}

		public interface IData
		{
			IWindowStackReference StackReference { get; }
			IGameEvent CloseTopWindowGameEvent { get; }
		}
	}
}