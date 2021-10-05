using UnityEngine;
using VEngine.SO.Variables;
using VEngine.Game.SO.Interaction;

namespace VEngine.Interaction
{
	public class InteractionController : MonoBehaviour
	{
		[SerializeField] private InteractorBaseBehaviour _interactor;
		[SerializeField] private InteractionData _interactionData;
		[SerializeField] private CameraDataVariable _cameraData;
		[SerializeField] private FloatReference _interactRayDistance;
		[SerializeField] private LayerMaskReference _interactableLayerMask;

		public void Update()
		{
			CheckRaycast(out var interactable);
			_interactionData.Interactable = interactable;
		}

		private bool CheckRaycast(out IInteractable interactable)
		{
			if (!Physics.Raycast(_cameraData.Position, _cameraData.Forward, out var hit, _interactRayDistance.Value, _interactableLayerMask.Value))
			{
				interactable = null;
				return false;
			}
			interactable = hit.collider.GetComponentInParent<IInteractable>();
			return interactable != null;
		}

		public void Interact(bool interact)
		{
			if (!interact || !CanInteractWith(_interactionData.Interactable))
				return;
			_interactionData.Interactable.OnInteracted(_interactor);
		}

		private bool CanInteractWith(IInteractable interactable)
		{
			return interactable != null && interactable.CanInteract(_interactor);
		}
	}
}