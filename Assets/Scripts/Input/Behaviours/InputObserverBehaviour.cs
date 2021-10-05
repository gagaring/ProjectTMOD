using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Input
{
	public abstract class InputObserverBehaviour : MonoBehaviour, InputObserver.IData
	{
		[SerializeField] private InputEnabledWithOnChangeEvent _isEnabled;

		public IVariableWithOnChangeEvent<bool> IsEnabled => _isEnabled;
		public IInputObserver Observer { get; private set; }

		protected abstract IInputObserver CreateObserver();

		public void Activate(bool active)
		{
			Observer.Activate(active);
		}

		protected void Awake()
		{
			Observer = CreateObserver();
			Observer.Activate(_isEnabled.Value);
		}

		private void Update()
		{
			if (!_isEnabled.Value)
				return;
			Observer.Update();
		}
	}
}
