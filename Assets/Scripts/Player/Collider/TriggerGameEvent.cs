using System.Collections;
using UnityEngine;
using VEngine.SO.Events;

namespace Assets.Scripts.Player.Collider
{
	[CreateAssetMenu(menuName = "SO/Collider/TriggerGameEvent")]
	public class TriggerGameEvent : TGameEvent<UnityEngine.Collider>
	{
	}
}