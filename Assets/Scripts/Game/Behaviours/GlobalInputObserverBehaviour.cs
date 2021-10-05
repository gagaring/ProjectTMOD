using System.Collections;
using UnityEngine;
using VEngine.Input;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.Game
{
	public class GlobalInputObserverBehaviour : InputObserverBehaviour, GlobalInputObserver.IGameData
	{
		[SerializeField] private GameEvent _globalCloseGameEvent;
		[SerializeField] private GameEvent _togglePlayerMenu;
		[SerializeField] private BoolReference _isGamePaused;

		public IGameEvent Close => _globalCloseGameEvent;
		public IGameEvent TogglePlayerMenu => _togglePlayerMenu;
		public bool IsGamePaused => _isGamePaused.Value;

		protected override IInputObserver CreateObserver() => new GlobalInputObserver(this, name);
	}
}