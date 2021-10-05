namespace VEngine.Enviroment.Rotate
{
	public interface IRotateBetweenFixes 
	{
		void Rotate(bool increase);
		void Update(float deltaTime);

		bool CanRotatePositive { get; }
		bool CanRotateNegative { get; }
	}
}