using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.TimeManagement
{
    [CreateAssetMenu(menuName = "SO/Time/GameSpeedGameEvent")]
    public class GameSpeedGameEvent : TGameEvent<IGameSpeed, bool>
    {
    }
}
