using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/IntVariable")]
	public class IntVariable : TVariable<int>
	{
	}

	[Serializable]
	public class IntReference : TReferenceWithConstant<int, IntVariable>
	{
	}
}
