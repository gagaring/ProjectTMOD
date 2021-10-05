using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/Vector2Variable")]
	public class Vector2Variable : TVariable<Vector2>
	{
	}

	[Serializable]
	public class Vector2Reference : TReferenceWithConstant<Vector2, Vector2Variable>
	{
	}
}
