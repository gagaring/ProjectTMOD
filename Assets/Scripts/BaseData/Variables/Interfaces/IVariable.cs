using VEngine.SO.Events;

namespace VEngine.SO.Variables
{
	public interface IVariable<T> 
	{
		T Value { get; set; }
	}

	public interface IVariableWithOnChangeEvent<T> 
	{
		IGameEvent<T> OnChangedEvent { get; }

		IVariable<T> Variable { get; }
		T Value { get; }
	}
}
