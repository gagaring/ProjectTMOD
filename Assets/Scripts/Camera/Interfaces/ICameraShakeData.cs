namespace VEngine.Camera
{
	public interface ICameraShakeData
	{
		float MaxAmplitude { get; }
		float Duration { get; }
		bool Infinite { get; }
		float CurrentAmplitude { get; }
		float CurrentFrequency { get; }

		bool IsActive { get; }

		void DoReset();
		void Activate(float rate);
		void DoUpdate(float deltaTime);
	}

	public interface ICameraShakeDataReference
	{
		public ICameraShakeData Data { get; }
	}
}
