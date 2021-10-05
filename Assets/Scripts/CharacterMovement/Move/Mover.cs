using UnityEngine;
using VEngine.Game.SO.Speed;

namespace VEngine.Game.Move
{
	[DisallowMultipleComponent]
	public abstract class Mover : MonoBehaviour
	{
		[SerializeField] protected SpeedReference _speed;
	} 
}
