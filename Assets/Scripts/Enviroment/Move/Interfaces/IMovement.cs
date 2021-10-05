
namespace VEngine.Enviroment.Move
{
	public interface IMovement
	{
		void SetDirection(bool open);
		void Do(float deltaTime);
		bool IsFinished();
	}

	public interface IMovements
	{
		void SetDirection(bool open);
		void Do(float deltaTime);
		bool IsFinished { get; }
		bool IsOpened { get; }
	}
}
