
using UnityEngine.Events;

namespace VEngine.SO.Events
{
	public class TGameEventListener<T> : IGameEventListener<T>
	{
        private readonly IData _data;

        public string Name => _data.Name;

        public TGameEventListener(IData data)
		{
            _data = data;
		}

		public void RegisterToEvent()
        {
            _data.Event.RegisterListener(this);
        }

        public void UnregisterFromEvent()
        {
            _data.Event?.UnregisterListener(this);
        }

        public void OnEventRaised(T value)
        {
            _data.Response.Invoke(value);
        }

        public interface IData
		{
            string Name { get; }
            IGameEvent<T> Event { get; }
            UnityEvent<T> Response { get; }
        }
    }
}
