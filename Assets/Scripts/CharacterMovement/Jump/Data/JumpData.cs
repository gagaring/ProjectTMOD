using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Game.SO.Jump
{
	[CreateAssetMenu(menuName = "SO/Variables/JumpData")]
	public class JumpData : ScriptableObject
	{
		[SerializeField] private BoolVariableWithOnChangeEvent _onJumpInProgress;
		
		public Vector3 Direction { get; set; }

		public bool SetInProgress { set => _onJumpInProgress.Value = value; }
	}
}
