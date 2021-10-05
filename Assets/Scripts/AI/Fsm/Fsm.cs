using System.Collections.Generic;
using UnityEngine;

namespace VEngine.AI.Fsm
{
	public class Fsm
	{
		private Stack<FsmState> _stateStack = new Stack<FsmState>();

		public delegate void FsmState(Fsm fsm, GameObject obj);

		public void Update(GameObject obj) => _stateStack.Peek()?.Invoke(this, obj);

		public void PushState(FsmState state) => _stateStack.Push(state);

		public void PopState() => _stateStack.Pop();
	}
}
