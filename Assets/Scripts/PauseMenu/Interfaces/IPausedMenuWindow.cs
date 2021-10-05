using VEngine.GUI;

namespace VEngine.PauseMenu
{
    public interface IPausedMenuWindow : IWindow
    {
        void OnResumeClicked();
    }
}
