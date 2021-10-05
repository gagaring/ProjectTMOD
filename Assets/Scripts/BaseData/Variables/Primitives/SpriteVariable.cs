using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/SpriteVariable")]
	public class SpriteVariable : TVariable<Sprite>
	{
	}

	[Serializable]
	public class SpriteReference : TReference<Sprite, SpriteVariable>
	{
	}
}
