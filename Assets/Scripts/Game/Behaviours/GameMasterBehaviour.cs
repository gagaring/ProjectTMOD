using UnityEngine;
using VEngine.SceneSystem;
using VEngine.SO.Variables;

namespace VEngine.Game
{
	public class GameMasterBehaviour : MonoBehaviour, GameMaster.IData
	{
		[SerializeField] private SceneListLoaderSO _defaultSceneLoader;
		[SerializeField] private GameGUIMasterBehaviour _gameGUIMaster;
		[SerializeField] private GameTimeControllerBehaviour _gameTimeController;
		[SerializeField] private BoolReference _isPausedMenuActive;
		[SerializeField] private bool _loadDefaults = true;

		private IGameMaster _gameMaster;

		public ISceneListLoader Loader => _defaultSceneLoader;
		public IGameGUIMaster GUIMaster => _gameGUIMaster.GUIMaster;
		public IGameTimeController GameTimeController => _gameTimeController.TimeController;
		public bool IsPausedMenuActive => _isPausedMenuActive.Value;

		private void Awake() => _gameMaster = new GameMaster(this);
		
		private void Start()
		{
			if (_loadDefaults)
				_gameMaster.LoadDefaultScenes();
		}

		public void OnClosePressed() => _gameMaster.OnClosePressed();
		public void PauseGame(bool pause) => _gameMaster.PauseGame(pause);

		string filename = "";
		void OnEnable() { Application.logMessageReceived += Log; }
		void OnDisable() { Application.logMessageReceived -= Log; }

		public void Log(string logString, string stackTrace, LogType type)
		{
			if (filename == "")
			{
				string d = System.Environment.GetFolderPath(
				  System.Environment.SpecialFolder.Desktop) + "/YOUR_LOGS";
				System.IO.Directory.CreateDirectory(d);
				filename = d + "/prototypeLog.txt";
			}
			try
			{
				System.IO.File.AppendAllText(filename, logString + "\n");
			}
			catch { }
		}

	}
}
