using VEngine.Input;
using VEngine.SO.Events;
using VEngine.TimeManagement;

namespace VEngine.Game
{
	public class GameTimeController : IGameTimeController
	{
		private readonly IData _data;

		public GameTimeController(IData data) => _data = data;

		public void PauseGame(bool pause)
		{
			_data.IsGamePaused = pause;
			_data.SetTime.Raise(pause ? _data.PausedGameSpeed : _data.NormalGameSpeed, true);
			_data.EmptyInput.Activate(pause);
		}

		public interface IData
		{ 
			IGameEvent<IGameSpeed, bool> SetTime { get; }
			IGameSpeed NormalGameSpeed { get; }
			IGameSpeed PausedGameSpeed { get; }
			IInputActivator EmptyInput { get; }
			bool IsGamePaused { get; set; }
		}
	}
}