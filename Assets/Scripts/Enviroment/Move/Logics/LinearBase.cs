using System;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Enviroment.Move
{
	[Serializable]
	public abstract class LinearBase : IMovement
	{
		[SerializeField] protected Data _baseData;
		[SerializeField] private Components _baseComponents;

		protected abstract void Process(float rate);

		private float _timer = 0;

		public Transform Target { get => _baseComponents.Target; }
		public Transform From { get; private set; }
		public Transform To { get; private set; }

		public void SetDirection(bool open)
		{
			_timer = _baseData.Duration - _timer;
			if (_timer < 0)
				_timer = 0.0f;
			if (open)
			{
				From = _baseComponents.From;
				To = _baseComponents.To;
			}
			else
			{
				From = _baseComponents.To;
				To = _baseComponents.From;
			}
		}

		public void Do(float deltaTime)
		{
			_timer += deltaTime;
			var rate = (_timer) / _baseData.Duration;
			if (rate > 1.0f)
				rate = 1.0f;
			Process(rate);
		}

		public bool IsFinished()
		{
			return _timer >= _baseData.Duration;
		}

		public interface IData
		{
			float Duration { get; }
		}

		[Serializable]
		public class Data : IData
		{
			[SerializeField] private FloatReference _duration;

			public float Duration => _duration.Value;
		}

		protected interface IComponents
		{
			Transform Target { get; }
			Transform From { get; }
			Transform To { get; }
		}

		[Serializable]
		private class Components : IComponents
		{
			[SerializeField] private Transform _target;
			[SerializeField] private Transform _from;
			[SerializeField] private Transform _to;

			public Transform Target { get => _target; }
			public Transform From => _from;
			public Transform To => _to;
		}
	}
}
