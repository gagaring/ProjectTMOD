using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.HandSystem;
using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.Artifacts.Throwables
{
	public class ThrowControllerBehaviour : ArtifactUseControllerBehaviour, IUseHandComponent, ThrowController.IThrowData
	{
		[Title("Data")]
		[SerializeField] private FloatReference _throwForce;
		[SerializeField] private BoolReference _canThrow;
		[SerializeField] private BoolReference _throwOnPressed;

		private ThrowController _throwController;
		
		public bool CanThrow => _canThrow.Value;
		public bool ThrowOn => _throwOnPressed.Value;
		public float ThrowForce => _throwForce.Value;

		private IThrowController ThrowController
		{
			get
			{
				CreateController();
				return _throwController;
			}
		}

		private void CreateController()
		{
			if (_throwController != null)
				return;
			_throwController = new ThrowController(this, this);
		}

		public override bool Use(IItem item, bool pressed, ITransformSOReference handPosition, ITransformSOReference viewDirection) 
			=> ThrowController.Use<ThrowableArtifactUseage>(item, pressed, handPosition.Position, viewDirection.Forward);
	}
}
