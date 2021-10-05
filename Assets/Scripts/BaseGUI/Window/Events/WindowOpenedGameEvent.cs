using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.GUI
{
	[CreateAssetMenu(menuName = "SO/BaseGUI/WindowOpenedGameEvent")]
    public class WindowOpenedGameEvent : TGameEvent<IWindow, bool>
    {
    }
}
