 using UnityEngine;
using VEngine.Enviroment;

namespace VEngine.LockAndKey
{
	public class LockTest : MonoBehaviour
	{
		[SerializeField] private ItemLockBehaviour _lock;
		[SerializeField] public Renderer _renderer;

		private void Awake()
		{
			_lock.OnChanged += OnChanged;
			OnChanged(false);
		}

		private void OnChanged(ISwitch obj, bool active)
		{
			OnChanged(active);
		}

		private void OnChanged(bool active)
		{
			_renderer.material.color = active ? Color.green : Color.red;
		}
	}
}