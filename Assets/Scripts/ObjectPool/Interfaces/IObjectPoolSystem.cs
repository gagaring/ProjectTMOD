using UnityEngine;

namespace VEngine.ObjectPool
{
	public interface IObjectPoolSystem
	{
		T Pull<T>(IObjectPoolEntity prefab) where T : MonoBehaviour;
		T Pull<T>(T prefab) where T : MonoBehaviour;
		void Push<T>(T obj) where T : MonoBehaviour;
	}
}
