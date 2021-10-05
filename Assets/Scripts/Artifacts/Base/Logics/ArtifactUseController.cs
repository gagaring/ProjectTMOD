using System;
using UnityEngine;
using VEngine.Items;

namespace VEngine.Artifacts
{
	public abstract class ArtifactUseController : IArtifactUseController
	{
		private readonly IData _data;

		protected abstract bool CanUse(bool pressed);
		protected abstract bool Use<T>(IArtifact artifact, IArtifactData data, T useage, Vector3 handPosition, Vector3 viewDirection) where T : IArtifactUseage;

		public ArtifactUseController(IData data)
		{
			_data = data;
		}

		public bool Use<T>(IItem item, bool pressed, Vector3 handPosition, Vector3 viewDirection) where T : IArtifactUseage
		{
			if (!CanUse(pressed))
				return false;

			var artifactItemComponent = ItemComponent.FindOn<ArtifactItemComponent>(item);
			if (artifactItemComponent == null)
				return false;

			return Use<T>(item, artifactItemComponent, handPosition, viewDirection);
		}

		private bool Use<T>(IItem item, ArtifactItemComponent artifactItemComponent, Vector3 handPosition, Vector3 viewDirection) where T : IArtifactUseage
		{
			if (!artifactItemComponent.GetUseage<T>(out var useage))
				return false;
			var artifact = GetEntity(item, artifactItemComponent);
			if(!Use(artifact, artifactItemComponent, useage, handPosition, viewDirection))
			{
				_data.PushArtifact(artifact);
				return false;
			}
			return true;
		}

		private IArtifact GetEntity(IItem item, IArtifactData data)
		{
			var artifact = _data.GetArtifact(data);
			artifact.Attached = item;
			return artifact;
		}

		public interface IData
		{
			IArtifact GetArtifact(IArtifactData data);
			void PushArtifact(IArtifact data);
		}
	}
}
