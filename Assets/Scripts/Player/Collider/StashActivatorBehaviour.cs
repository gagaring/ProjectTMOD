using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Player.TEMP
{
	//TODO ez nem ide es nem igy kene
    public class StashActivatorBehaviour : MonoBehaviour
    {
        [SerializeField] private BoolVariable _stashActive;

		private void Awake()
		{
			_stashActive.Value = false;
		}

		public void OnTriggerEnter(Collider other)
		{
			if (!GetPlayer(other, out PlayerBehaviour player))
				return;
			_stashActive.Value = true;
		}

		public void OnTriggerExit(Collider other)
		{
			if (!GetPlayer(other, out PlayerBehaviour player))
				return;
			_stashActive.Value = false;
		}

		private bool GetPlayer(Collider collider, out PlayerBehaviour player)
		{
			player = collider.GetComponent<PlayerBehaviour>();
			return player != null;
		}
	}
}
