using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VEngine.SceneSystem
{
	[CreateAssetMenu(menuName = "SO/Scene/SceneData")]
	public class SceneData : SerializedScriptableObject, ISceneData
	{
		[SerializeField][PropertyRange(0, "_max")] public int BuildIndex { get; private set; }
		[SerializeField] [ReadOnly] [MultiLineProperty] public string Name { get; private set; }

#if UNITY_EDITOR
		private static int _max;

		private void OnValidate()
		{
			RefreshMaxBuildIndex();
			Name = BuildIndex < 0 || BuildIndex >= SceneManager.sceneCountInBuildSettings ? "Undefined scene" : GetNameByIndex();
		}

		private string GetNameByIndex()
		{
			var name = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
			return name.Replace("Assets/Scenes/Game/", "").Replace(".unity", "");
		}

		[Button("Refresh max buildindex")]
		private void RefreshMaxBuildIndex()
		{
			_max = SceneManager.sceneCountInBuildSettings - 1;
		}
#endif
	}
}
