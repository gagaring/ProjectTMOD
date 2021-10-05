using UnityEngine;
using VEngine.Game.SO.MoveState;

namespace VEngine.Game.Move
{
	public class MoveStateController : MonoBehaviour
	{
		[SerializeField] private MoveStatePriorityList _moveStateList;

		private void Update()
		{
			_moveStateList.RaiseBest();
		}
	}
}