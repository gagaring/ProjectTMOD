using System.Collections.Generic;
using VEngine.Enviroment.Move;

namespace VEngine.Interaction.Command
{
	public class MoveItemToCommand : ICommand
	{
		private readonly IData _data;
		private readonly IComponents _components;

		private bool _open;

		public virtual string Name => GetType().Name;

		public MoveItemToCommand(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			_open = true;
		}

		public void OnStart(IInteractor interactor)
		{
			SetupMovements(_components.Moves);
			SetupMovements(_components.Rotates);
		}

		private void SetupMovements(IReadOnlyList<IMovement> moves)
		{
			foreach (var curr in moves)
				curr.SetDirection(_open);
		}

		public virtual bool OnUpdate(IInteractor interactor, float deltaTime)
		{
			return UpdateAllMovements(deltaTime);
		}

		private bool UpdateAllMovements(float deltaTime)
		{
			bool moves = UpdateMovements(_components.Moves, deltaTime);
			bool rotate = UpdateMovements(_components.Rotates, deltaTime);
			return moves && rotate;
		}

		private bool UpdateMovements(IReadOnlyList<IMovement> moves, float deltaTime)
		{
			bool allGood = true;
			foreach (var curr in moves)
			{
				curr.Do(deltaTime);
				if (!curr.IsFinished())
					allGood = false;
			}
			return allGood;
		}

		public virtual void OnExit(IInteractor interactor)
		{
			_open = !_open;
		}

		public void DoReset()
		{
		}

		public interface IData
		{
		}

		public interface IComponents
		{
			IReadOnlyList<IMovement> Moves { get; }
			IReadOnlyList<IMovement> Rotates { get; }
		}
	}

}
