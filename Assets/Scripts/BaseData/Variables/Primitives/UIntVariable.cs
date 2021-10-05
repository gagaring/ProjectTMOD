using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/UIntVariable")]
	public class UIntVariable : TVariable<uint>
	{
	}

	[Serializable]
	public class UIntReference : TReferenceWithConstant<uint, UIntVariable>
	{
	}
}
