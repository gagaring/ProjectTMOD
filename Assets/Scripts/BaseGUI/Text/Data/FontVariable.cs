using System;
using TMPro;
using UnityEngine;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName ="SO/Fonts/FontVariable")]
	public class FontVariable : TVariable<TMP_FontAsset>
	{
	}


	[Serializable]
	public class FontReference : TReferenceWithConstant<TMP_FontAsset, FontVariable>
	{
	}
}
