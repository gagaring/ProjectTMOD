using UnityEngine;

namespace VEngine.ObjectPool
{
    public class TestObjectPoolClient : ObjectPoolClientBehaviour<TestObjectPoolEntityBehaviour>
	{
		private TestObjectPoolEntityBehaviour _current;

		private void Awake()
		{
			InvokeRepeating(nameof(Pull), 1.0f, 0.1f);
		}

		private void Pull()
		{
			if (_current != null)
				System.Push(_current);
			_current = System.Pull<TestObjectPoolEntityBehaviour>(_entity);
			_current.gameObject.SetActive(true);
			_current.Hello();
		}
	}
}
