using UnityEngine;
using VEngine.Log;
using VEngine.SO.Events;

namespace VEngine.GUI
{
	public abstract class Window : Panel, IWindow
	{
		private readonly IWindowData _data;

		public Window(IWindowData data) : base(data)
		{
			_data = data;
			VLog.Log(VLog.eFlag.GUI, VLog.eLevel.Normal, $"Window created - {Name}");
		}

		protected override void OnWindowOpened(bool opened)
		{
			base.OnWindowOpened(opened);
			_data.OnOpened.Raise(this, opened);
		}

		public interface IWindowData : IPanelData
		{
			IGameEvent<IWindow, bool> OnOpened { get; } 
		}
	}
}
