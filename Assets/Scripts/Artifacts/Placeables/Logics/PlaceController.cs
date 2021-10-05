using UnityEngine;

namespace VEngine.Artifacts.Placeables
{
	public class PlaceController : ArtifactUseController, IPlaceController
	{
		private readonly IPlaceData _data;
		private IPlacer _placer;

		public PlaceController(IData baseData, IPlaceData placeData) : base(baseData)
		{
			_data = placeData;
			_placer = new Placer();
		}

		protected override bool CanUse(bool pressed)
		{
			return _data.CanPlace && (_data.PlaceOn == pressed);
		}

		protected override bool Use<T>(IArtifact artifact, IArtifactData data, T useage, Vector3 handPosition, Vector3 viewDirection)
		{
			if (!ArtifactUseage.ConvertUseage<PlaceableArtifactUseage>(useage, out var placeableUseage))
				return false;

			return Use(artifact, data, placeableUseage, handPosition, viewDirection);
		}

		private bool Use(IArtifact artifact, IArtifactData data, PlaceableArtifactUseage placeableUseage, Vector3 handPosition, Vector3 viewDirection)
		{
			if (!PlaceableTargeter.Targeting(placeableUseage.Data, handPosition, viewDirection, out var targetingResult))
				return false;
			if (!_placer.Place(artifact, targetingResult.Position, targetingResult.Normal))
				return false;
			OnArtifactPlaced(artifact, data);
			return true;
		}

		private void OnArtifactPlaced(IArtifact artifact, IArtifactData data)
		{
			var useageEvent = data.GetUseageEvent<OnArtifactPlaced>();
			if (useageEvent == null)
				return;
			useageEvent.Use(artifact);
		}

		public interface IPlaceData
		{
			bool CanPlace { get; }
			bool PlaceOn { get; }
		}
	}
}