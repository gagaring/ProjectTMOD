using UnityEngine;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/GameObjectVariableWithOnChangeEvent")]
	public class GameObjectVariableWithOnChangeEvent : TVariableWithOnChangeEvent<GameObject>
	{
		protected override bool CheckSame(GameObject other)
		{
			return Value == other;
		}
	}
}
