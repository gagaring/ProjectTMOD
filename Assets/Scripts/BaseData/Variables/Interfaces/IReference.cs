namespace VEngine.SO.Variables
{
	public interface IReference<T, V> where V : IVariable<T>
	{
		V Variable { get; }
		T Value { get; }
	}

	public interface IReferenceWithConstant<T, V> where V : IVariable<T>
	{
		bool UseConstant { get; }
		T ConstantValue { get; }
		V Variable { get; }
		T Value { get; }
		bool IsValid { get; }
	}

	public interface IReferenceWithOnChangeEvent<T, V> where V : IVariableWithOnChangeEvent<T>
	{
		public T Value { get; }
	}
}