using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/FloatVariable")]
	public class FloatVariable : TVariable<float>
	{
	}

	[Serializable]
	public class FloatReference : TReferenceWithConstant<float, FloatVariable>
	{
	}
}
