using System;
using UnityEngine;
using VEngine.Log;
using VEngine.SO.Variables;
using VEngine.TimerSystem;

namespace VEngine.Artifacts.Commands
{
	[CreateAssetMenu(menuName = "SO/Artifacts/Useage/Commands/StartTimerCommand")]
	public class StartTimerCommand : ArtifactCommand
	{
		[SerializeField] private TimerGameEvent _onTimerStarted;
		[SerializeField] private FloatReference _duration;

		public override void Use(IArtifact artifact)
		{
			ITimable timable = new Timable(_duration.Value, () => OnExpired(artifact));
			_onTimerStarted.Raise(timable);
		}

		public void OnExpired(IArtifact artifact)
		{
			if (!ArtifactUtils.GetUseageEvent<OnArtifactTimerExpired>(artifact, out var useageEvent))
			{
				VLog.Log(VLog.eFlag.Game, VLog.eLevel.Error, $"Timer van rajta, de semmi sem figyeli");
				return;
			}
			useageEvent.Use(artifact);
		}
	}
}