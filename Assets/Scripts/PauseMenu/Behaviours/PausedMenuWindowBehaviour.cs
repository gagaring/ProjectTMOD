using UnityEngine;
using VEngine.GUI;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.PauseMenu
{
	public class PausedMenuWindowBehaviour : WindowBehaviour, PausedMenuWindow.IPausedMenuData
	{
		[SerializeField] private BoolGameEvent _pauseGameEvent;
		[SerializeField] private BoolVariable _isPausedMenuOpened;

		public IGameEvent<bool> PauseGame => _pauseGameEvent;

		public bool IsOpened { set => _isPausedMenuOpened.Value = value; }

		protected override IWindow CreateWindow() => new PausedMenuWindow(this);

		public void OnResumeClicked() => ((IPausedMenuWindow)Window).OnResumeClicked();

		protected void Start() => Close();
	}
}