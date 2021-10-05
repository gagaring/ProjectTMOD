using UnityEngine;

namespace VEngine.ObjectPool
{
	public interface IObjectPool<T> where T : MonoBehaviour
	{
		int Id { get; }
		void Push(T t);
		T Pull();
	}
}
