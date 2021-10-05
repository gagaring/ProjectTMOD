namespace VEngine.TimerSystem
{
	public interface ITimerSystem
	{
		void StartTimer(ITimable timable);
		void Update(float deltaTime);
	}
}