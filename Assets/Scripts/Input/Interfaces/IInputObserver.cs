namespace VEngine.Input
{
	public interface IInputObserver
	{
		void Activate(bool active);
		void Update();
	}
}
