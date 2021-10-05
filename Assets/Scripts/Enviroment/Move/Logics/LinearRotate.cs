using System;
using UnityEngine;

namespace VEngine.Enviroment.Move
{
	[Serializable]
	public class LinearRotate : LinearBase
	{
		Quaternion TargetRotation { get => Target.rotation; set => Target.rotation = value; }
		Quaternion FromRotation => From.rotation;
		Quaternion ToRotation => To.rotation;

		protected override void Process(float rate)
		{
			TargetRotation = Quaternion.Lerp(FromRotation, ToRotation, rate);
		}
	}
}
