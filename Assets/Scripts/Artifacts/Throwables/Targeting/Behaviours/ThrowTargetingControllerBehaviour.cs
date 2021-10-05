using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.HandSystem;
using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.Artifacts.Throwables
{
	public class ThrowTargetingControllerBehaviour : TargetingControllerBehaviour, ITargetingHandComponent, ThrowTargetingController.IThrowData
	{
		[SerializeField] private FloatReference _throwForce;
		[Title("Raycast")]
		[SerializeField] private IntReference _maximumCollisionAttemptCount;
		[SerializeField] private LayerMaskReference _canHit;
		[SerializeField] private FloatReference _raycastDistance;

		[Title("Marker")]
		[SerializeField] public GameObject Marker { get; private set; }

		public float ThrowForce => _throwForce.Value;

		public int MaxCollisionAttemptCount => _maximumCollisionAttemptCount.Value;
		public int LayerMask => _canHit.Value;
		public float RaycastDistance => _raycastDistance.Value;

		protected override ITargetingController CreateController()
		{
			return new ThrowTargetingController(this, this);
		}

		public bool Targeting(IItem item, bool pressed, ITransformSOReference handPosition, ITransformSOReference viewDirection)
			=> _contoller.Targeting<ThrowableArtifactUseage>(item, pressed, handPosition, viewDirection);
	}
}