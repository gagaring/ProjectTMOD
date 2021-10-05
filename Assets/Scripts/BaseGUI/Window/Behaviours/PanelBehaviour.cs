using System.Collections;
using UnityEngine;

namespace VEngine.GUI
{
	public abstract class PanelBehaviour : MonoBehaviour, Panel.IPanelData
	{
		[SerializeField] private GameObject _main;

		private IPanel _panel;

		protected abstract IPanel CreatePanel();

		public GameObject Main => _main;
		public string Name => name;

		public void Open(bool open) => _panel.Open(open);
		public void Open() => _panel.Open();
		public void Close() => _panel.Close();
		public void Toggle() => _panel.Toggle();

		public IPanel Panel
		{
			get
			{
				CreatePanelIfNeed();
				return _panel;
			}
		}

		protected virtual void Awake() => CreatePanelIfNeed();

		private void CreatePanelIfNeed()
		{
			if (_panel != null)
				return;
			_panel = CreatePanel();
		}
	}
}