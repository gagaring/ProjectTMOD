using System;
using UnityEngine;

namespace VEngine.SO.Variables
{
	public class TReference<T, V> : IReference<T, V> where V : TVariable<T>
	{
		[SerializeField] private V _variable;
		
		public V Variable { get => _variable; }
		public T Value { get => Variable.Value; }

		public void Init(V variable)
		{
			_variable = variable;
		}
	}

	[Serializable]
	public class TReferenceWithConstant<T, V> : IReferenceWithConstant<T, V> where V : TVariable<T>
	{
		[SerializeField] private bool _useConstant;
		[SerializeField] private T _constantValue;
		[SerializeField] private V _variable;
		
		public bool UseConstant { get => _useConstant; set => _useConstant = value; }
		public T ConstantValue => _constantValue;
		public T Value => UseConstant ? ConstantValue : Variable.Value;
		public V Variable => _variable;
		public bool IsValid => UseConstant || Variable != null;

		public void Init(T constant)
		{
			_constantValue = constant;
			UseConstant = true;
		}

		public void Init(V variable)
		{
			_variable = variable;
			UseConstant = false;
		}
	}

	[Serializable]
	public class TReferenceWithOnChangeEvent<T, V> : IReferenceWithOnChangeEvent<T, V> where V : TVariableWithOnChangeEvent<T>
	{
		[SerializeField] private V _variable;

		public T Value { get => _variable.Value; }

		public void Init(V variable)
		{
			_variable = variable;
		}
	}
}
