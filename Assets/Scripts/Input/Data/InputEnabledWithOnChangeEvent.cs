using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Input
{
	[CreateAssetMenu(menuName = "SO/Variables/InputEnabledWithOnChangeEvent")]
	public class InputEnabledWithOnChangeEvent : BoolVariableWithOnChangeEvent
	{
		protected override bool CheckSame(bool other)
		{
			return false;
		}
	}
}
