using UnityEngine;
using VEngine.HandSystem;
using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.Artifacts.Placeables
{
	public class PlaceTargetingControllerBehaviour : TargetingControllerBehaviour, ITargetingHandComponent, PlaceTargetingController.IPlaceData
	{
		[SerializeField] public GameObject Marker { get; private set; }

		public bool Targeting(IItem item, bool pressed, ITransformSOReference handPosition, ITransformSOReference viewDirection)
			=> _contoller.Targeting<PlaceableArtifactUseage>(item, pressed, handPosition, viewDirection);

		protected override ITargetingController CreateController()
		{
			return new PlaceTargetingController(this, this);
		}
	}
}