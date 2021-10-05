using UnityEngine;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/Vector3VariableWithOnChangeEvent")]
	public class Vector3VariableWithOnChangeEvent : TVariableWithOnChangeEvent<Vector3>
	{
		protected override bool CheckSame(Vector3 other)
		{
			return Value == other;
		}
	}
}
