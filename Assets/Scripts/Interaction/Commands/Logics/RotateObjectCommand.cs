using VEngine.Enviroment.Rotate;

namespace VEngine.Interaction.Command
{
	public class RotateObjectCommand : RotatorClampTransform, ICommand
	{
		public string Name => GetType().Name;
		private readonly ICommandData _commandData;

		public RotateObjectCommand(ICommandData data, IComponents components) : base(data.BaseData, components)
		{
			_commandData = data;
			_commandData.IsFinished = false;
		}

		public void DoReset()
		{
			_commandData.IsFinished = false;
		}

		public void OnExit(IInteractor interactor)
		{
		}

		public void OnStart(IInteractor interactor)
		{
			_commandData.IsFinished = false;
		}

		public bool OnUpdate(IInteractor interactor, float deltaTime)
		{
			RotateX(_commandData.RotateX, deltaTime);
			RotateY(_commandData.RotateY, deltaTime);
			return _commandData.IsFinished;
		}


		public interface ICommandData
		{
			IData BaseData { get; }
			bool IsFinished { get; set; }
			float RotateX { get; }
			float RotateY { get; }
		}
	}
}
