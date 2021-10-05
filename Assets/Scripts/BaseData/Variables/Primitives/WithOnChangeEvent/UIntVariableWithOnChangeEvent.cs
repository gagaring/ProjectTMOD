using UnityEngine;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/UIntVariableWithOnChangeEvent")]
	public class UIntVariableWithOnChangeEvent : TVariableWithOnChangeEvent<uint>
	{
		protected override bool CheckSame(uint other)
		{
			return Value == other;
		}
	}
}
