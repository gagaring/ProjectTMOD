using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.GUI;
using VEngine.SO.Events;

namespace VEngine.Game
{
	public class GameGUIMasterBehaviour : SerializedMonoBehaviour, GameGUIMaster.IData
	{
		[SerializeField] private IWindowStackReference _windowStackReference;
		[SerializeField] private IGameEvent _closeTopWindowGameEvent;

		private IGameGUIMaster _guiMaster = null;

		public IWindowStackReference StackReference => _windowStackReference;
		public IGameEvent CloseTopWindowGameEvent => _closeTopWindowGameEvent;

		public IGameGUIMaster GUIMaster
		{
			get
			{
				CreateGUIMaster();
				return _guiMaster;
			}
		}

		private void CreateGUIMaster()
		{
			if (_guiMaster != null)
				return;
			_guiMaster = new GameGUIMaster(this);
		}
	}
}