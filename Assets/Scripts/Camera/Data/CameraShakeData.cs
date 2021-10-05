using UnityEngine;
using VEngine.Camera;

namespace VEngine.SO.Camera
{
	public class CameraShakeData : ScriptableObject, ICameraShakeData
	{
		[SerializeField] private float _maxFrequency;
		[SerializeField] private float _maxAmplitude;
		[SerializeField] private float _duration;
		[SerializeField] private bool _infinite;

		public float MaxFrequency { get => _maxFrequency; set => _maxFrequency = value; }
		public float MaxAmplitude { get => _maxAmplitude; set => _maxAmplitude = value; }
		public float Duration { get => _duration; set => _duration = value; }
		public bool Infinite { get => _infinite; set => _infinite = value; }

		public float CurrentAmplitude { get; private set; }
		public float CurrentFrequency { get; private set; }

		public bool IsActive { get => (_infinite || _remainingDuration > 0.0f) && CurrentAmplitude > 0.0f; }

		private float _remainingDuration;

		public void DoReset()
		{
			Activate(0.0f);
		}

		public void Activate(float rate)
		{
			_remainingDuration = _duration;
			SetIntesity(rate);
			SetFrequency(rate);
		}

		private void SetIntesity(float rate)
		{
			var currIntesity = _maxAmplitude * rate;
			Utils.MinMax(ref currIntesity, 0.0f, _maxAmplitude);
			CurrentAmplitude = currIntesity;
		}

		private void SetFrequency(float rate)
		{
			var currFreq = _maxFrequency * rate;
			Utils.MinMax(ref currFreq, 0.0f, _maxFrequency);
			CurrentFrequency = currFreq;
		}

		public void DoUpdate(float deltaTime)
		{
			if (!IsActive || Infinite)
				return;

			_remainingDuration -= deltaTime;
		}
	}

	public class CameraShakeDataReference : ICameraShakeDataReference
	{
		[SerializeField] private readonly CameraShakeData _data;

		public ICameraShakeData Data { get => _data; }

		public CameraShakeDataReference(CameraShakeData data)
		{
			_data = data;
		}
	}
}
