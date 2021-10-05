using UnityEngine;

namespace VEngine.Artifacts.Throwables
{
	public class ThrowController : ArtifactUseController, IThrowController
	{
		private readonly IThrowData _data;

		public ThrowController(IData baseData, IThrowData data) : base(baseData)
		{
			_data = data;
		}

		protected override bool CanUse(bool pressed)
		{
			return _data.CanThrow && (_data.ThrowOn == pressed);
		}

		protected override bool Use<T>(IArtifact artifact, IArtifactData data, T useage, Vector3 handPosition, Vector3 viewDirection)
		{
			if (!ArtifactUseage.ConvertUseage<ThrowableArtifactUseage>(useage, out var throwableUsage))
				return false;

			return Use(artifact, data, throwableUsage, handPosition, viewDirection);
		}

		private bool Use(IArtifact artifact, IArtifactData data, ThrowableArtifactUseage throwableUsage, Vector3 handPosition, Vector3 viewDirection)
		{
			if (!Thrower.Throw(artifact, throwableUsage.Data, handPosition, viewDirection, _data.ThrowForce))
				return false;
			OnArtifactThrown(artifact, data);
			return true;
		}

		private void OnArtifactThrown(IArtifact artifact, IArtifactData data)
		{
			var useageEvent = data.GetUseageEvent<OnArtifactThrown>();
			if (useageEvent == null)
				return;
			useageEvent.Use(artifact);
		}

		public interface IThrowData
		{
			bool CanThrow { get; }
			bool ThrowOn { get; }
			float ThrowForce { get; }
		}
	}
}
