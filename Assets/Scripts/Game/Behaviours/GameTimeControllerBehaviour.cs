using UnityEngine;
using VEngine.SO.Events;
using VEngine.Input;
using VEngine.TimeManagement;
using VEngine.SO.Variables;

namespace VEngine.Game
{
	public class GameTimeControllerBehaviour : MonoBehaviour, GameTimeController.IData
	{
		[SerializeField] private GameSpeedGameEvent _setTimeGameEvent;
		[SerializeField] private GameSpeed _normalGameSpeed;
		[SerializeField] private GameSpeed _pausedGameSpeed;
		[SerializeField] private InputActivator _emptyInput;
		[SerializeField] private BoolVariableWithOnChangeEvent _isGamePaused;

		private IGameTimeController _timeController = null;

		public IGameTimeController TimeController
		{
			get
			{
				CreateTimeController();
				return _timeController;
			}
		}

		public IGameSpeed PausedGameSpeed => _pausedGameSpeed;
		public IGameSpeed NormalGameSpeed => _normalGameSpeed;
		public IGameEvent<IGameSpeed, bool> SetTime => _setTimeGameEvent;
		public IInputActivator EmptyInput => _emptyInput;

		public bool IsGamePaused { get => _isGamePaused.Value; set => _isGamePaused.Value = value; }

		private void Awake() => CreateTimeController();

		private void CreateTimeController()
		{
			if (_timeController != null)
				return;
			_isGamePaused.Value = false;
			_timeController = new GameTimeController(this);
		}
	}
}