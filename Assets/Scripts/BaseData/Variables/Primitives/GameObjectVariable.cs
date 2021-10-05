using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/GameObjectVariable")]
	public class GameObjectVariable : TVariable<GameObject>
	{
	}

	[Serializable]
	public class GameObjectReference : TReference<GameObject, GameObjectVariable>
	{
	}
}
