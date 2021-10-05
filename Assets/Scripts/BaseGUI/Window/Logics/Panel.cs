using UnityEngine;

namespace VEngine.GUI
{
	public abstract class Panel : IPanel
	{
		private readonly IPanelData _data;
		protected bool _isOpened;

		public string Name => _data.Name;

		public Panel(IPanelData data)
		{
			_data = data;
			_isOpened = true;
		}

		public void Toggle()
		{
			Open(!_isOpened);
		}

		public virtual void Open(bool open)
		{
			if (_data.Main.activeSelf == open)
				return;
			if (open)
				Open();
			else
				Close();
		}

		public virtual void Open()
		{
			OnWindowOpened(true);
		}

		public virtual void Close()
		{
			OnWindowOpened(false);
		}

		protected virtual void OnWindowOpened(bool opened)
		{
			_isOpened = opened;
			_data.Main.SetActive(opened);
		}

		public interface IPanelData
		{
			GameObject Main { get; }
			string Name { get; }
		}
	}
}
