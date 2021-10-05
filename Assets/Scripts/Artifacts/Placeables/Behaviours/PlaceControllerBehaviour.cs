using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.HandSystem;
using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.Artifacts.Placeables
{
	public class PlaceControllerBehaviour : ArtifactUseControllerBehaviour, IUseHandComponent, PlaceController.IPlaceData
	{
		[Title("Data")]
		[SerializeField] private BoolReference _canPlace;
		[SerializeField] private BoolReference _placeOnPressed;

		private IPlaceController _controller;

		public bool CanPlace => _canPlace.Value;
		public bool PlaceOn => _placeOnPressed.Value;

		public override bool Use(IItem item, bool pressed, ITransformSOReference handPosition, ITransformSOReference viewDirection)
			=> _controller.Use<PlaceableArtifactUseage>(item, pressed, handPosition.Position, viewDirection.Forward);

		private void Awake()
			=> _controller = new PlaceController(this, this);
	}
}