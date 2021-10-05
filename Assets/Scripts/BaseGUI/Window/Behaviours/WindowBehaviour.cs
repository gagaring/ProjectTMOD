using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.GUI
{
	public abstract class WindowBehaviour : PanelBehaviour, Window.IWindowData
	{
		protected abstract IWindow CreateWindow();

		[SerializeField] private WindowOpenedGameEvent _onOpened;

		public IGameEvent<IWindow, bool> OnOpened => _onOpened;

		public IWindow Window => (IWindow)Panel;

		protected override IPanel CreatePanel() => CreateWindow();
	}
}
