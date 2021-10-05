using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.SceneSystem
{
	[CreateAssetMenu(menuName = "SO/Scene/SceneListLoaderSO")]
	public class SceneListLoaderSO : SerializedScriptableObject, ISceneListLoader
	{
		[SerializeField] private ISceneDataList _scenes;
		[SerializeField] private ISceneLoadData _loadSceneData;
		[SerializeField] private IGameEvent<ISceneDataList, ISceneLoadData> _loadScenesEvent;

		public void LoadScenes()
		{
			_loadScenesEvent.Raise(_scenes, _loadSceneData);
		}
	}
}