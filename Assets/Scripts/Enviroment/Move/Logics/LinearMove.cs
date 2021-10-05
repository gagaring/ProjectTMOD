using System;
using UnityEngine;

namespace VEngine.Enviroment.Move
{
	[Serializable]
	public class LinearMove : LinearBase
	{
		private Vector3 TargetPosition { get => Target.position; set => Target.position = value; }
		private Vector3 FromPosition => From.position;
		private Vector3 ToPosition => To.position;

		protected override void Process(float rate)
		{
			TargetPosition = Vector3.Lerp(FromPosition, ToPosition, rate);
		}
	}
}
