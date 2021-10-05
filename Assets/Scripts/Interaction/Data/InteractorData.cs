using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Game.SO.Interaction
{
	[CreateAssetMenu(menuName = "SO/Interaction/InteractorData")]
	public class InteractorData : ScriptableObject
	{
		public Vector3Variable Position;
		public QuaternionVariable Rotation;
	}
}
