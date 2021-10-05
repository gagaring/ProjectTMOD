using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/Vector3Variable")]
	public class Vector3Variable : TVariable<Vector3>
	{
	}

	[Serializable]
	public class Vector3Reference : TReferenceWithConstant<Vector3, Vector3Variable>
	{
	}
}
