namespace VEngine.TimerSystem
{
	public interface ITimable
	{
		float Duration { get; }
		void OnExpired();
	}
}
