using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VEngine.Log;

namespace VEngine.SceneSystem
{
    public class SceneSystemBehaviour : SerializedMonoBehaviour
    {
        [SerializeField][ReadOnly] private HashSet<ISceneData> _loadedScenes = new HashSet<ISceneData>();
		private Queue<LoadingData> _loadingQueue = new Queue<LoadingData>();

		Coroutine _loadingRoutine = null;

		public void LoadScene(ISceneData sceneData, ISceneLoadData loadData)
		{
			_loadingQueue.Enqueue(new LoadingData(sceneData, loadData));
			OnQueueChanged();
		}

		public void LoadScenes(ISceneDataList sceneDataList, ISceneLoadData loadData)
		{
			LoadScenes(sceneDataList.List, loadData);
		}

		public void LoadScenes(IReadOnlyList<ISceneData> sceneDataList, ISceneLoadData loadData)
		{
			foreach (var curr in sceneDataList)
				_loadingQueue.Enqueue(new LoadingData(curr, loadData));
			OnQueueChanged();
		}

		private void OnQueueChanged()
		{
			VLog.Log(VLog.eFlag.Scene, VLog.eLevel.Normal, $"Scene loading queue changed. Elements in queue: {_loadingQueue.Count}, loadRunning: {_loadingRoutine != null}");
			if (_loadingQueue.Count == 0 || _loadingRoutine != null)
				return;
			var loadingData = _loadingQueue.Dequeue();
			if(loadingData.LoadData.Load)
				StartLoadScene(loadingData);
			else
				StartUnloadScene(loadingData);
		}

		private void StartLoadScene(LoadingData loadingData)
		{
			if (_loadedScenes.Contains(loadingData.SceneData))
			{
				VLog.Log(VLog.eFlag.Scene, VLog.eLevel.Warning, $"Scene is already loaded: {loadingData.SceneData.Name} (BuildIndex: {loadingData.SceneData.BuildIndex})");
				return;
			}
			_loadingRoutine = StartCoroutine(StartLoadSceneRoutine(loadingData));
		}

		private void StartUnloadScene(LoadingData loadingData)
		{
			if (!_loadedScenes.Contains(loadingData.SceneData))
			{
				VLog.Log(VLog.eFlag.Scene, VLog.eLevel.Warning, $"Scene is not loaded: {loadingData.SceneData.Name} (BuildIndex: {loadingData.SceneData.BuildIndex})");
				return;
			}
			_loadingRoutine = StartCoroutine(StartUnloadSceneRoutine(loadingData));
		}

		private IEnumerator StartLoadSceneRoutine(LoadingData loadingData)
		{
			VLog.Log(VLog.eFlag.Scene, VLog.eLevel.Normal, $"Scene load started: {loadingData.SceneData.Name} (BuildIndex: {loadingData.SceneData.BuildIndex})");
			var operation = SceneManager.LoadSceneAsync(loadingData.SceneData.BuildIndex, LoadSceneMode.Additive);
			yield return Process(operation);
			_loadedScenes.Add(loadingData.SceneData);
			OnLoadDone();
		}

		private IEnumerator StartUnloadSceneRoutine(LoadingData loadingData)
		{
			VLog.Log(VLog.eFlag.Scene, VLog.eLevel.Normal, $"Scene unload started: {loadingData.SceneData.Name} (BuildIndex: {loadingData.SceneData.BuildIndex})");
			var operation = SceneManager.UnloadSceneAsync(loadingData.SceneData.BuildIndex);
			yield return Process(operation);
			_loadedScenes.Remove(loadingData.SceneData);
			OnLoadDone();
		}

		private IEnumerator Process(AsyncOperation operation)
		{
			while (!EvaulateOperation(operation, out var progress))
				yield return null;
		}

		private void OnLoadDone()
		{
			_loadingRoutine = null;
			VLog.Log(VLog.eFlag.Scene, VLog.eLevel.Normal, $"Scene (un)load finished");
			OnQueueChanged();
		}

		private bool EvaulateOperation(AsyncOperation operation, out float progress)
		{
			if (operation == null || operation.isDone || operation.progress == 0.9f)
			{
				progress = 1.0f;
				return true;
			}
			progress = operation.progress / .9f;
			return false;
		}

		public struct LoadingData
		{
			public ISceneData SceneData { get; private set; }
			public ISceneLoadData LoadData { get; private set; }
			
			public LoadingData(ISceneData data, ISceneLoadData loadData)
			{
				SceneData = data;
				LoadData = loadData;
			}
		}
	}
}
