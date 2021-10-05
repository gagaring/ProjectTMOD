using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.SO.Variables
{
	public abstract class TVariable<T> : ScriptableObject, IVariable<T>
	{
		[SerializeField] private T _value;

		public T Value { get => _value; set => _value = value; }
	}

	public abstract class TVariableWithOnChangeEvent<T> : ScriptableObject, IVariableWithOnChangeEvent<T>
	{
		[SerializeField] private TVariable<T> _value;
		[SerializeField] private TGameEvent<T> _onChangedEvent;

		public IGameEvent<T> OnChangedEvent { get => _onChangedEvent; }
		public IVariable<T> Variable { get => _value; }

		public T Value
		{
			get => Variable.Value;
			set
			{
				if (CheckSame(value))
					return;
				_value.Value = value;
				OnChangedEvent.Raise(value);
			}
		}

		public void SetOnChangeEvent(TGameEvent<T> gameEvent)
		{
			_onChangedEvent = gameEvent;
		}

		public void SetVariable(TVariable<T> variable)
		{
			_value = variable;
		}

		protected abstract bool CheckSame(T other);
	}
}
