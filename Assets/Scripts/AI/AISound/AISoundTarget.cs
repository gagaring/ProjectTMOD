using VEngine.AI.Senses.Sensors.Hearing;
using UnityEngine;

namespace VEngine.Game.Player.AISound
{
	public class AISoundTarget : HearingTarget
	{
		[SerializeField] private eAISoundType _type;

		public eAISoundType Type { get => _type; }

		public void Activate(bool activate)
		{
			gameObject.SetActive(activate);
		}
	}
}