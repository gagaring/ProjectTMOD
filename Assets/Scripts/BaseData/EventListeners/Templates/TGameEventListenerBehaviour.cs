using System;
using UnityEngine;
using UnityEngine.Events;

namespace VEngine.SO.Events
{
    public class TGameEventListenerBehaviour<T> : MonoBehaviour, TGameEventListener<T>.IData
    {
        [SerializeField] private TGameEvent<T> _event;
        [SerializeField] private UnityEvent<T> _response;

        public IGameEvent<T> Event => _event;
        public UnityEvent<T> Response => _response;
        public string Name => name;

        public IGameEventListener<T> _listener;
        public IGameEventListener<T> Listener 
        { 
            get
			{
                if (_listener == null)
                    CreateListener();
                return _listener;
			}
        }

		private void CreateListener()
		{
            _listener = new TGameEventListener<T>(this);
		}

		protected void OnEnable()
        {
            Listener.RegisterToEvent();
        }

        protected void OnDisable()
        {
            Listener.UnregisterFromEvent();
        }
    }

    public class TGameEventListenerBehaviour<T1, T2> : MonoBehaviour, IGameEventListener<T1, T2>
    {
        [Tooltip("Event to register with.")]
        [SerializeField] private TGameEvent<T1, T2> _event;

        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField] private UnityEvent<T1, T2> _response;

        public string Name => name;

        protected void OnEnable()
        {
            _event.RegisterListener(this);
        }

        protected void OnDisable()
        {
            _event.UnregisterListener(this);
        }

        public void OnEventRaised(T1 v1, T2 v2)
        {
            _response.Invoke(v1, v2);
        }
    }

    public class TGameEventListenerBehaviour<T1, T2, T3> : MonoBehaviour, IGameEventListener<T1, T2, T3>
    {
        [Tooltip("Event to register with.")]
        [SerializeField] private TGameEvent<T1, T2, T3> _event;

        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField] private UnityEvent<T1, T2, T3> _response;

        public string Name => name;

        protected void OnEnable()
        {
            _event.RegisterListener(this);
        }

        protected void OnDisable()
        {
            _event.UnregisterListener(this);
        }

        public void OnEventRaised(T1 v1, T2 v2, T3 v3)
        {
            _response.Invoke(v1, v2, v3);
        }
    }


    public class TGameEventListenerBehaviour<T1, T2, T3, T4> : MonoBehaviour, IGameEventListener<T1, T2, T3, T4>
    {
        [Tooltip("Event to register with.")]
        [SerializeField] private TGameEvent<T1, T2, T3, T4> _event;

        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField] private UnityEvent<T1, T2, T3, T4> _response;

        public string Name => name;

        protected void OnEnable()
        {
            _event.RegisterListener(this);
        }

        protected void OnDisable()
        {
            _event.UnregisterListener(this);
        }

        public void OnEventRaised(T1 v1, T2 v2, T3 v3, T4 v4)
        {
            _response.Invoke(v1, v2, v3, v4);
        }
    }
}
