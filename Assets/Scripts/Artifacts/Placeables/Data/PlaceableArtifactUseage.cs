using UnityEngine;

namespace VEngine.Artifacts.Placeables
{
	[CreateAssetMenu(menuName = "SO/Artifacts/Useage/Placeable")]
	public class PlaceableArtifactUseage : ArtifactUseage
	{
		[SerializeField] private PlaceableData _data;

		public IPlaceableData Data => _data;
	}
}
