using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/StringVariable")]
	public class StringVariable : TVariable<string>
	{
	}

	[Serializable]
	public class StringReference : TReferenceWithConstant<string, StringVariable>
	{
	}
}
