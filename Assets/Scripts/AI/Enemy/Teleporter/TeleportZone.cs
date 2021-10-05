using System;
using UnityEngine;
using VEngine.Player;

namespace VEngine.AI.Enemy.Teleporter
{
	public class TeleportZone : MonoBehaviour
	{
		[SerializeField] private float _teleportCooldown;

		public Action<TeleportZone> OnPlayerReachedNewZone { get; set; }
		public float TeleporterCooldown { get => _teleportCooldown; }

		public void OnTriggerEnter(Collider other)
		{
			var player = other.GetComponentInParent<PlayerBehaviour>();
			if (player == null)
				return;
			OnPlayerReachedNewZone?.Invoke(this);
		}
	}
}