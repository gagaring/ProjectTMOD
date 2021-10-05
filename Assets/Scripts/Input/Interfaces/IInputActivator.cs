namespace VEngine.Input
{
	public interface IInputActivator 
	{
		void Activate(bool activate);
		void Activate();
		void Deactivate();
	}
}
