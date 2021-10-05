using UnityEngine;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/BoolVariableWithOnChangeEvent")]
	public class BoolVariableWithOnChangeEvent : TVariableWithOnChangeEvent<bool>
	{
		protected override bool CheckSame(bool other)
		{
			return Value == other;
		}
	}
}
