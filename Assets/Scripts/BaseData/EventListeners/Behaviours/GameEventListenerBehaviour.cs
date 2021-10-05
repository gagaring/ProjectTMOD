using UnityEngine;
using UnityEngine.Events;

namespace VEngine.SO.Events
{
    public class GameEventListenerBehaviour : MonoBehaviour, IGameEventListener
    {
        [Tooltip("Event to register with.")]
        [SerializeField] private GameEvent _event;
    
        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField] private UnityEvent _response;

		public string Name => name;

		private void OnEnable()
        {
            _event.RegisterListener(this);
        }

        private void OnDisable()
        {
            _event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            _response.Invoke();
        }
    }
}
