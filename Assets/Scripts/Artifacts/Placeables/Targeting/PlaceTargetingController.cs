using UnityEngine;
using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.Artifacts.Placeables
{
	public class PlaceTargetingController : TargetingController
	{
		private readonly IPlaceData _data;
		private readonly TargetingData _currentTargeting = new TargetingData();

		public PlaceTargetingController(IData data, IPlaceData throwData) : base(data)
		{
			_data = throwData;
			TargetingSuccess(false);
		}

		protected override bool Targeting<T>(IItem item, IArtifactData data, T useage, ITransformSOReference handPosition, ITransformSOReference viewDirection)
		{
			if (!ArtifactUseage.ConvertUseage<PlaceableArtifactUseage>(useage, out var placeableUseage))
				return false;
			_currentTargeting.PlaceData = placeableUseage.Data;
			_currentTargeting.HandPosition = handPosition;
			_currentTargeting.ViewDirection = viewDirection;
			return true;
		}

		protected override void Reset()
		{
			_currentTargeting.PlaceData = null;
			_data.Marker.gameObject.SetActive(false);
		}

		protected override void DoUpdate(float deltaTime)
		{
			if(!PlaceableTargeter.Targeting(_currentTargeting.PlaceData, _currentTargeting.HandPosition.Position, _currentTargeting.ViewDirection.Forward, out var result))
			{
				_data.Marker.SetActive(false);
				return;
			}
			_data.Marker.SetActive(true);
			_data.Marker.transform.position = result.Position;
			_data.Marker.transform.forward = result.Normal;
			return;
		}

		public interface IPlaceData : IData
		{
			GameObject Marker { get; }
		}

		private class TargetingData
		{
			public ITransformSOReference HandPosition { get; set; }
			public ITransformSOReference ViewDirection { get; set; }
			public IPlaceableData PlaceData { get; set; }
		}
	}
}
