using Sirenix.OdinInspector;
using UnityEngine;

namespace VEngine.SceneSystem
{
	[CreateAssetMenu(menuName = "SO/Scene/SceneLoadData")]
	public class SceneDataLoad : SerializedScriptableObject, ISceneLoadData
	{
		[SerializeField] public bool Load { get; private set; }
	}
}
