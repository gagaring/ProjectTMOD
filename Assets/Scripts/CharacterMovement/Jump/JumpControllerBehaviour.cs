using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Variables;
using VEngine.Game.SO.Jump;

namespace VEngine.Game.Entity.Jump
{
	public class JumpControllerBehaviour : MonoBehaviour
	{
		[SerializeField] private TransformSO _target;
		[SerializeField] private FloatReference _maxAngle;
		[SerializeField] private JumpData _jumpData;

		private HashSet<Jumpable> _jumpables = new HashSet<Jumpable>();

		private Jumping _currentJump = null;

		private void Awake()
		{
			_jumpData.SetInProgress = false;
		}

		public void Jump(bool jump)
		{
			if (!jump || _currentJump != null)
				return;
			if (!GetBestLandingPoint(out var landingPoint, out var jumpable))
				return;
			Jump(landingPoint, jumpable);
		}

		private void Jump(Vector3 landingPoint, Jumpable jumpable)
		{
			_currentJump = new Jumping(_target, landingPoint, jumpable);
			_currentJump.OnFinished += OnJumpFinished;
			_jumpData.Direction = (landingPoint - _target.Position).normalized;
			_jumpData.SetInProgress = true;
		}

		private void OnJumpFinished()
		{
			_currentJump = null;
			_jumpData.SetInProgress = false;
		}

		private bool GetBestLandingPoint(out Vector3 landingPoint, out Jumpable jumpable)
		{
			landingPoint = Vector3.negativeInfinity;
			jumpable = null;
			if (_jumpables.Count == 0)
				return false;

			float maxAngle = _maxAngle.Value;
			foreach (var curr in _jumpables)
			{
				if (!curr.GetLandingPoint(_target.Position, _target.Forward, ref maxAngle, ref landingPoint))
					continue;
				jumpable = curr;
			}
			return jumpable != null;
		}

		private void Update()
		{
			_currentJump?.Update(Time.deltaTime);
		}

		public void TriggerEnter(Collider other)
		{
			if (!GetJumpable(other, out var jumpable))
				return;
			_jumpables.Add(jumpable);
		}

		public void TriggerExit(Collider other)
		{
			if (!GetJumpable(other, out var jumpable))
				return;
			_jumpables.Remove(jumpable);
		}

		private bool GetJumpable(Collider other, out Jumpable jumpable)
		{
			jumpable = other.GetComponent<Jumpable>();
			return jumpable != null;
		}

		private class Jumping
		{
			private float _timer = 0.0f;

			private Vector3 _startPoint;
			private Vector3 _endPosition;
			private TransformSO _jumper;
			private Jumpable _jumpable;

			private AnimationCurve HeightCurve { get => _jumpable.HeightCurve; }
			private float Height { get => _jumpable.Height; }
			private float Duration { get => _jumpable.Duration; }

			public Action OnFinished { get; set; }

			public Jumping(TransformSO jumper, Vector3 endPosition, Jumpable jumpable)
			{
				_jumper = jumper;
				_startPoint = jumper.Position;
				_endPosition = endPosition;
				_jumpable = jumpable;
			}

			public void Update(float deltaTime)
			{
				_timer += deltaTime;
				var rate = _timer / Duration;
				if (rate < 1.0f)
				{
					var currentPosition = Vector3.Lerp(_startPoint, _endPosition, rate);
					currentPosition.y += HeightCurve.Evaluate(rate) * Height;
					_jumper.Position = currentPosition;
				}
				else
				{
					_jumper.Position = _endPosition;
					OnFinished.Invoke();
				}
			}
		}
	}
}