using UnityEngine;
using VEngine.Interaction;
using VEngine.SO.Variables;

namespace VEngine.Player
{
	public class PlayerInteractorBehaviour : InteractorBaseBehaviour
	{
		[SerializeField] private TransformSO _playerTransform;

		public override Vector3 Position { get => _playerTransform.Position; set => _playerTransform.Position = value; }
		public override Quaternion Rotation { get => _playerTransform.Rotation; set => _playerTransform.Rotation = value; }
	}
}
