using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Game.SO.MoveState
{
	[CreateAssetMenu(menuName = "SO/MoveState/MoveStatePriorityList")]
	public class MoveStatePriorityList : ScriptableObject
	{
		[SerializeField] private List<MoveStateSO> _priorityList = new List<MoveStateSO>();
		
		private MoveStateSO _current = null;

		public void RaiseBest()
		{
			for(int i = 0; i < _priorityList.Count; ++i)
			{
				var curr = _priorityList[i];
				if (!curr.Check())
					continue;
				if (_current == curr)
					return;
				_current?.OnExit.Raise();
				curr.OnEnter.Raise();
				_current = curr;
				return;
			}
		}

		private void OnDisable()
		{
			_current = null;
		}
	}
}