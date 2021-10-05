using System.Collections;
using UnityEngine;

namespace VEngine.Anim
{
	public class TeleporterAnimatorController : CAnimatorBase
	{
		protected override void RegisterHashes()
		{
			SetHash(eFloat.Speed);
		}

		public void OnSpeedChanged(float speed, float maxSpeed)
		{
			speed /= maxSpeed;
			Set(eFloat.Speed, speed);
		}
	}
}