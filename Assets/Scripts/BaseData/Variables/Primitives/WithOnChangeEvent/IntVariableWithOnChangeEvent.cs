using UnityEngine;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/IntVariableWithOnChangeEvent")]
	public class IntVariableWithOnChangeEvent : TVariableWithOnChangeEvent<int>
	{
		protected override bool CheckSame(int other)
		{
			return Value == other;
		}
	}
}
