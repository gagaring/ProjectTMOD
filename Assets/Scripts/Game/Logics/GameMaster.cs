using VEngine.SceneSystem;

namespace VEngine.Game
{
	public class GameMaster : IGameMaster
	{
		private readonly IData _data;

		public GameMaster(IData data) => _data = data;

		public void LoadDefaultScenes() => _data.Loader.LoadScenes();
		public void PauseGame(bool pause) => _data.GameTimeController.PauseGame(pause);

		public void OnClosePressed()
		{
			//if (_data.IsIteractionActive)
			//{
			//	//TODO: Interaction interrupt
			//	return;
			//}
			if (_data.GUIMaster.OpenedWindowCount == 0)
			{
				PauseGame(true);
				return;
			}
			_data.GUIMaster.CloseWindow();
			/*
			 * Kell nezni a paused menu-t, mivel ha pl options uj ablakot nyit rajta, akkor annak bezarasakor
			 * nem kell meg elinditani a jatekot.
			*/
			PauseGame(_data.IsPausedMenuActive);
		}

		public interface IData
		{
			ISceneListLoader Loader { get; }
			IGameGUIMaster GUIMaster { get; }
			IGameTimeController GameTimeController { get; }
			bool IsPausedMenuActive { get; }
		}
	}
}