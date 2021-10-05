using System;
using UnityEngine;
using VEngine.Player;

namespace VEngine.AI.Enemy.Teleporter
{
	public class TeleportTrigger : MonoBehaviour
	{
		[SerializeField] private Transform _teleportPlace;

		public Action<TeleportTrigger> OnPlayerEntered { get; set; }
		public Vector3 TeleportPosition { get => _teleportPlace.position; }

		private void OnTriggerEnter(Collider other)
		{
			var player = other.GetComponentInParent<PlayerBehaviour>();
			if (player == null)
				return;
			OnPlayerEntered?.Invoke(this);
		}
	}
}