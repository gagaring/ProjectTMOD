using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.SO.Events;

namespace Assets.Scripts.Player.Collider
{
	public class TriggerEnterDetection : SerializedMonoBehaviour
	{
		[SerializeField] private IGameEvent<UnityEngine.Collider> _onTriggerEnter;

		public void OnTriggerEnter(UnityEngine.Collider other)
		{
			_onTriggerEnter.Raise(other);
		}
	}
}