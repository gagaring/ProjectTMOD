using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/BoolVariable")]
	public class BoolVariable : TVariable<bool>
	{
	}

	[Serializable]
	public class BoolReference : TReferenceWithConstant<bool, BoolVariable>
	{
	}
}
