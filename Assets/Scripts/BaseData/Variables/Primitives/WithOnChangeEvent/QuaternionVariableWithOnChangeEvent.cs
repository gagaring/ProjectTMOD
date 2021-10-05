using UnityEngine;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/QuaternionVariableWithOnChangeEvent")]
	public class QuaternionVariableWithOnChangeEvent : TVariableWithOnChangeEvent<Quaternion>
	{
		protected override bool CheckSame(Quaternion other)
		{
			return Value == other;
		}
	}
}
