using UnityEngine;
using VEngine.Artifacts;
using VEngine.SO.Variables;

namespace VEngine.DamageSystem
{
	[CreateAssetMenu(menuName = "SO/Item/ItemComponents/HealComponent")]
	public class HealOnUseComponent : UseComponent
	{
		[SerializeField] private FloatReference _healAmount;

		public float HealAmount => _healAmount.Value;
	}
}
