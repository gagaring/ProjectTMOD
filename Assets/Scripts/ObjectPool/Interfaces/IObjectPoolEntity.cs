using UnityEngine;

namespace VEngine.ObjectPool
{
	public interface IObjectPoolEntity
	{
		int Id { get; }
		GameObject Prefab { get; }
	}
}
