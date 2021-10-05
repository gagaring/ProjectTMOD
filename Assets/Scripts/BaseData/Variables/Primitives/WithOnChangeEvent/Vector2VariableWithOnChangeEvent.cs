using UnityEngine;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/Vector2VariableWithOnChangeEvent")]
	public class Vector2VariableWithOnChangeEvent : TVariableWithOnChangeEvent<Vector2>
	{
		protected override bool CheckSame(Vector2 other)
		{
			return Value == other;
		}
	}
}
