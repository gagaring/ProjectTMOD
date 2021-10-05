using System.Collections.Generic;
using UnityEngine;
using VEngine.Log;

namespace VEngine.SO.Events
{
    public class TGameEvent<T> : ScriptableObject, IGameEvent<T>
    {
        private readonly List<IGameEventListener<T>> _eventListeners = new List<IGameEventListener<T>>();

        public int RegisteredCount { get => _eventListeners.Count; }

        public void Raise(T value)
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(value);
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
                VLog.Log(VLog.eFlag.Event, VLog.eLevel.Normal, $"RegisterListener: {listener.Name} -> {name}");
            }
        }

        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
                VLog.Log(VLog.eFlag.Event, VLog.eLevel.Normal, $"UnregisterListener: {listener.Name} -> {name}");
            }
        }
    }

    public class TGameEvent<T1, T2> : ScriptableObject, IGameEvent<T1, T2>
    {
        private readonly List<IGameEventListener<T1, T2>> _eventListeners = new List<IGameEventListener<T1, T2>>();

        public int RegisteredCount => _eventListeners.Count;

        public void Raise(T1 v1, T2 v2)
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(v1, v2);
        }

        public void RegisterListener(IGameEventListener<T1, T2> listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
                VLog.Log(VLog.eFlag.Event, VLog.eLevel.Normal, $"RegisterListener: {listener.Name} -> {name}");
            }
        }

        public void UnregisterListener(IGameEventListener<T1, T2> listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
                VLog.Log(VLog.eFlag.Event, VLog.eLevel.Normal, $"UnregisterListener: {listener.Name} -> {name}");
            }
        }
    }

    public class TGameEvent<T1, T2, T3> : ScriptableObject, IGameEvent<T1, T2, T3>
    {
        private readonly List<IGameEventListener<T1, T2, T3>> _eventListeners = new List<IGameEventListener<T1, T2, T3>>();

        public int RegisteredCount => _eventListeners.Count;

        public void Raise(T1 v1, T2 v2, T3 v3)
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(v1, v2, v3);
        }

        public void RegisterListener(IGameEventListener<T1, T2, T3> listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
                VLog.Log(VLog.eFlag.Event, VLog.eLevel.Normal, $"RegisterListener: {listener.Name} -> {name}");
            }
        }

        public void UnregisterListener(IGameEventListener<T1, T2, T3> listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
                VLog.Log(VLog.eFlag.Event, VLog.eLevel.Normal, $"UnregisterListener: {listener.Name} -> {name}");
            }
        }
    }

    public class TGameEvent<T1, T2, T3, T4> : ScriptableObject, IGameEvent<T1, T2, T3, T4>
    {
        private readonly List<IGameEventListener<T1, T2, T3, T4>> _eventListeners = new List<IGameEventListener<T1, T2, T3, T4>>();

        public int RegisteredCount => _eventListeners.Count;

        public void Raise(T1 v1, T2 v2, T3 v3, T4 v4)
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(v1, v2, v3, v4);
        }

        public void RegisterListener(IGameEventListener<T1, T2, T3, T4> listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
                VLog.Log(VLog.eFlag.Event, VLog.eLevel.Normal, $"RegisterListener: {listener.Name} -> {name}");
            }
        }

        public void UnregisterListener(IGameEventListener<T1, T2, T3, T4> listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
                VLog.Log(VLog.eFlag.Event, VLog.eLevel.Normal, $"UnregisterListener: {listener.Name} -> {name}");
            }
        }
    }
}
