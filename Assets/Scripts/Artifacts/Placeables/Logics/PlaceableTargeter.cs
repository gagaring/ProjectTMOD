using UnityEngine;

namespace VEngine.Artifacts.Placeables
{
	public static class PlaceableTargeter
	{
		public static bool Targeting(IPlaceableData data, Vector3 startPosition, Vector3 viewDirection, out ITargetingResult result)
		{
			if (!Physics.Raycast(startPosition, viewDirection, out var hit, data.MaxRange, data.PlaceableLayers)
				|| Utils.IsActiveLayerInLayerMask(data.UnplaceableLayers, (uint)hit.collider.gameObject.layer))
			{
				result = null;
				return false;
			}
			result = new TargetingResult(hit);
			return true;
		}

		public interface ITargetingResult
		{
			Vector3 Position { get; }
			Vector3 Normal { get; }
		}

		private class TargetingResult : ITargetingResult
		{
			public Vector3 Position { get; private set; }
			public Vector3 Normal { get; private set; }

			public TargetingResult(RaycastHit hit)
			{
				Position = hit.point;
				Normal = hit.normal;
			}
		}
	}
}