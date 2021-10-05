using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.SceneSystem
{
    public class SceneLoadingDetectorBehaviour : SerializedMonoBehaviour
    {
		[SerializeField] private List<ISceneData> _scenes;
		[SerializeField] private ISceneLoadData _loadData;
		[SerializeField] private IGameEvent<IReadOnlyList<ISceneData>, ISceneLoadData> _loadEvent;

		public void OnTriggerEnter(Collider other)
		{
			_loadEvent.Raise(_scenes, _loadData);
		}
	}
}
