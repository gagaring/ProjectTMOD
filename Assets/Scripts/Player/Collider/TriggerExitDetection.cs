using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.SO.Events;

namespace Assets.Scripts.Player.Collider
{
	public class TriggerExitDetection : SerializedMonoBehaviour
	{
		[SerializeField] private IGameEvent<UnityEngine.Collider> _onTriggerExit;

		public void OnTriggerExit(UnityEngine.Collider other)
		{
			_onTriggerExit.Raise(other);
		}
	}
}