namespace VEngine.Interaction.Command
{
	public class OpenGateWithCodeCommand : OpenGateCommand
	{
		private readonly ICodeData _data;

		public override string Name => GetType().Name;

		public OpenGateWithCodeCommand(ICodeData data) : base(data)
		{
			_data = data;
		}

		public override void OnStart(IInteractor interactor)
		{
			if (!_data.PasswordLock.IsUnlocked) //Nem nyitjuk ki az ajtot
				return;
			base.OnStart(interactor);
		}

		public override bool OnUpdate(IInteractor interactor, float deltaTime)
		{
			if (!_data.PasswordLock.IsUnlocked) //Nem nyitjuk ki az ajtot
				return true;
			return base.OnUpdate(interactor, deltaTime);
		}

		public override void OnExit(IInteractor interactor)
		{
			if (!_data.PasswordLock.IsUnlocked) //Nem nyitottunk ajtot
				return;
			base.OnExit(interactor);
		}

		public interface ICodeData : IData
		{
			IPasswordLock PasswordLock { get; }
		}
	}
}