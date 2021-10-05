using VEngine.Input;
using VEngine.SO.Events;

namespace VEngine.Game
{
    public class GlobalInputObserver : InputObserver
	{
		private readonly IGameData _data;

		public GlobalInputObserver(IGameData data, string name = "") : base(data, name)
		{
			_data = data;
			Register(_input.Global.Close, ctx => { if (IsPushed(ctx)) _data.Close.Raise(); }, false);
			Register(_input.Global.TogglePlayerMenu, ctx => 
			{ 
				if (IsPushed(ctx) && !_data.IsGamePaused) 
					_data.TogglePlayerMenu.Raise(); 
			
			}, false);
		}

		protected override void Reset()
		{
		}

		public interface IGameData : IData
		{
			IGameEvent Close { get; }
			IGameEvent TogglePlayerMenu { get; }
			bool IsGamePaused { get; }
		}
	}
}
