namespace VEngine.Game
{
    public interface IGameMaster 
    {
        void LoadDefaultScenes();
        void OnClosePressed();
        void PauseGame(bool paused);

    }
}
