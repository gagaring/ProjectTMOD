using UnityEngine;

namespace VEngine.ObjectPool
{
	public interface IObjectPoolData
	{
		int Id { get; }
		int DefaultNumber { get; } 
		GameObject Prefab { get; }
	}
}
