using UnityEngine;

namespace VEngine.AI.Senses
{
	public abstract class SenseBase : MonoBehaviour
	{
		[SerializeField] private int _priority;

		public int Priority { get => _priority; }
	}
}
