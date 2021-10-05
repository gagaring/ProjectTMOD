using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.SceneSystem
{
	[CreateAssetMenu(menuName = "SO/Scene/SceneDataList")]
	public class SceneDataList : SerializedScriptableObject, ISceneDataList
	{
		[SerializeField] private List<ISceneData> _list;
		public IReadOnlyList<ISceneData> List => _list;
	}
}
