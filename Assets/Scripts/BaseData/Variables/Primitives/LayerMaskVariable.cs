using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/LayerMaskVariable")]
	public class LayerMaskVariable : TVariable<LayerMask>
	{
	}

	[Serializable]
	public class LayerMaskReference : TReferenceWithConstant<LayerMask, LayerMaskVariable>
	{
	}
}
