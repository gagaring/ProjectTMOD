using UnityEngine;

namespace VEngine.Artifacts.Placeables
{
	public interface IPlaceableData 
	{
		float MaxRange { get; }
		LayerMask PlaceableLayers { get; }
		LayerMask UnplaceableLayers { get; }
	}
}