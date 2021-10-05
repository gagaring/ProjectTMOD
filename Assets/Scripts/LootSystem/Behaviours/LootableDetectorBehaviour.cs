using UnityEngine;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.LootSystem
{
    public class LootableDetectorBehaviour : MonoBehaviour, LootableDetector.IData
    {
		[SerializeField] private LayerMaskReference _detectionRaycastLayerMask;
		[SerializeField] private FloatReference _range;
		[SerializeField] private TransformSO _cameraTransform;
		[SerializeField] private LootableGameEvent _onLootableFound;

		public LayerMask DetectionRaycastLayerMask => _detectionRaycastLayerMask.Value;
		public float Range => _range.Value;
		public Vector3 StartPosition => _cameraTransform.Position;
		public Vector3 ForwardDirection => _cameraTransform.Forward;
		public IGameEvent<ILootable> OnLootableSelected => _onLootableFound;
		
		private ILootableDetector _detector;

		private void Awake() => _detector = new LootableDetector(this);
		private void Update() => _detector.FindLootable();
	}
}
