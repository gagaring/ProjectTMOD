using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Game.SO.MoveState
{
	public abstract class MoveStateSO : ScriptableObject
	{
		public GameEvent OnEnter;
		public GameEvent OnExit;

		public abstract bool Check();
	}
}