using System;
using UnityEngine;
using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.Artifacts
{
	public abstract class TargetingController : ITargetingController
	{
		private readonly IData _data;

		protected abstract bool Targeting<T>(IItem item, IArtifactData data, T useage, ITransformSOReference handPosition, ITransformSOReference viewDirection) where T : IArtifactUseage;
		protected abstract void Reset();
		protected abstract void DoUpdate(float deltaTime);

		public TargetingController(IData targetingData)
		{
			_data = targetingData;
		}

		public bool Targeting<T>(IItem item, bool pressed, ITransformSOReference handPosition, ITransformSOReference viewDirection) where T : IArtifactUseage
		{
			return TargetingSuccess(TargetingImp<T>(item, pressed, handPosition, viewDirection));
		}

		private bool TargetingImp<T>(IItem item, bool pressed, ITransformSOReference handPosition, ITransformSOReference viewDirection) where T : IArtifactUseage
		{
			if (!pressed)
				return false;
			var artifactItemComponent = ItemComponent.FindOn<ArtifactItemComponent>(item);
			if (artifactItemComponent == null)
				return false;

			return Targeting<T>(item, artifactItemComponent, handPosition, viewDirection);
		}

		private bool Targeting<T>(IItem item, ArtifactItemComponent artifactItemComponent, ITransformSOReference handPosition, ITransformSOReference viewDirection) where T : IArtifactUseage
		{
			if (!artifactItemComponent.GetUseage<T>(out var useage))
				return false;
			return Targeting(item, artifactItemComponent, useage, handPosition, viewDirection);
		}

		protected bool TargetingSuccess(bool success)
		{
			_data.IsTargetingActive = success;
			if (success)
				return true;
			Reset();
			return false;
		}

		public void Update(float deltaTime)
		{
			if (!_data.IsTargetingActive)
				return;
			DoUpdate(deltaTime);
		}

		public interface IData
		{
			bool IsTargetingActive { get; set; }
		}
    }
}
