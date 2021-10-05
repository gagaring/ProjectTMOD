using System.Collections.Generic;
using UnityEngine;
using VEngine.Log;

namespace VEngine.SO.Events
{
    [CreateAssetMenu(menuName = "SO/Events/GameEvent")]
    public class GameEvent : ScriptableObject, IGameEvent
    {
        private readonly List<IGameEventListener> _eventListeners = new List<IGameEventListener>();

        public int RegisteredCount => _eventListeners.Count;

        public void Raise()
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised();
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
                VLog.Log(VLog.eFlag.Event, VLog.eLevel.Normal, $"RegisterListener: {listener.Name} -> {name}");
            }
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
                VLog.Log(VLog.eFlag.Event, VLog.eLevel.Normal, $"UnregisterListener: {listener.Name} -> {name}");
            }
        }
	}
}
