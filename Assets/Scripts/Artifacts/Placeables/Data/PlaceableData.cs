using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Artifacts.Placeables
{
	[CreateAssetMenu( menuName = "SO/Artifacts/PlaceableData")]
	public class PlaceableData : ScriptableObject, IPlaceableData
	{
		[SerializeField] private FloatReference _maxPlaceRange;
		[SerializeField] private LayerMaskReference _raycastMask;
		[SerializeField] private LayerMaskReference _unplaceableLayerMask;

		public float MaxRange => _maxPlaceRange.Value;
		public LayerMask PlaceableLayers => _raycastMask.Value;
		public LayerMask UnplaceableLayers => _unplaceableLayerMask.Value;
	}
}