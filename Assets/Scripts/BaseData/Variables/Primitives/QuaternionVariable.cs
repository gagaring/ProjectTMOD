using UnityEngine;
using System;

namespace VEngine.SO.Variables
{
	[CreateAssetMenu(menuName = "SO/Variables/QuaternionVariable")]
	public class QuaternionVariable : TVariable<Quaternion>
	{
	}

	[Serializable]
	public class QuaternionReference : TReference<Quaternion, QuaternionVariable>
	{
	}
}
