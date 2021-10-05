using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Player
{
	public class ColliderController : MonoBehaviour
	{
		public enum eColliderType
		{
			Normal,
			Crouch
		}

		[SerializeField] private CharacterController _characterController;
		[SerializeField] List<SCollider> _colliders;

		private eColliderType ColliderType
		{
			set
			{
				var next = _colliders.Find(x => x.Type == value);
				_characterController.height = next.Height;
				var center = _characterController.center;
				center.y = next.Offset;
				_characterController.center = center;
			}
		}

		public void OnCrouch(bool crouch)
		{
			ColliderType = crouch ? eColliderType.Crouch : eColliderType.Normal;
		}

		[Serializable]
		private struct SCollider
		{
			public eColliderType Type;
			public float Height;
			public float Offset;
		}
	}
}