using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Game.Items
{
	public class Flashlight : MonoBehaviour
	{
		[SerializeField] private Light _light;
		[SerializeField] private List<Collider> _lightTriggers;
		[SerializeField] private float _energyDropPercentPerSec = 0.33333f;

		[Header("FollowTarget")]
		[SerializeField] private Transform _positionTarget;
		[SerializeField] private Transform _rotateTarget;

		public float _energy = 100.0f;
		private bool _isActive = false;

		public void Turn(bool turn)
		{
			if (!_isActive && !CanTurnOn())
				return;
			_light.gameObject.SetActive(turn);
			TurnTriggers(turn);
			_isActive = turn;
		}

		private void TurnTriggers(bool turn)
		{
			foreach(var curr in _lightTriggers)
				curr.gameObject.SetActive(turn);
		}

		private bool CanTurnOn()
		{
			return _energy > 0.0f;
		}

		private void Update()
		{
			UpdateEnergy();
			FollowTarget();
		}

		private void UpdateEnergy()
		{
			if (_energy <= 0.0f)
				return;
			_energy -= _energyDropPercentPerSec * Time.deltaTime;
			if (_energy <= 0.0f)
				Turn(false);
		}

		private void FollowTarget()
		{
			transform.position = _positionTarget.position;
			transform.LookAt(transform.position + _rotateTarget.forward);
		}
	}
}