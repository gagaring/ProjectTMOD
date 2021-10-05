using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/ColorVariable")]
	public class ColorVariable : TVariable<Color>
	{
	}

	[Serializable]
	public class ColorReference : TReferenceWithConstant<Color, ColorVariable>
	{
	}
}
