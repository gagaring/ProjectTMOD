using System.Collections;
using UnityEngine;
using VEngine.Items;

namespace VEngine.Artifacts
{
	public static class ArtifactUtils
	{
		public static bool GetUseageEvent<T>(IArtifact artifact, out T useageEvent) where T : IArtifactUseageEvent
		{
			return GetUseageEvent(artifact.Attached, out useageEvent);
		}

		public static bool GetUseageEvent<T>(IItem item, out T useageEvent) where T : IArtifactUseageEvent
		{
			return GetUseageEvent(ItemComponent.FindOn<ArtifactItemComponent>(item), out useageEvent);
		}

		public static bool GetUseageEvent<T>(IArtifactData data, out T useageEvent) where T : IArtifactUseageEvent
		{
			useageEvent = data.GetUseageEvent<T>();
			return useageEvent != null;
		}
	}
}