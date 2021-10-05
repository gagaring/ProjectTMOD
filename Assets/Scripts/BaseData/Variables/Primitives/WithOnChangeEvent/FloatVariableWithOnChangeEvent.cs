using UnityEngine;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/FloatVariableWithOnChangeEvent")]
	public class FloatVariableWithOnChangeEvent : TVariableWithOnChangeEvent<float>
	{
		protected override bool CheckSame(float other)
		{
			return Value == other;
		}
	}
}
