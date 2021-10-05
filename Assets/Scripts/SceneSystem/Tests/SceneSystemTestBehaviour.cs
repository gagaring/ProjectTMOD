using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using VEngine.SceneSystem;
using VEngine.SO.Events;

namespace VTest.SceneSystem
{
    public class SceneSystemTestBehaviour : SerializedMonoBehaviour
    {
        [SerializeField] private IGameEvent<ISceneData, ISceneLoadData> _loadEvent;

        [Title("Single")]
        public ISceneData _data;
        public ISceneLoadData _loadData;
        [Title("All")]
        public List<ISceneData> _dataList;
        public List<ISceneLoadData> _loadDataList;

        [Button("LoadSingle")]
        public void Load()
        {
            _loadEvent.Raise(_data, _loadData);
        }

        [Button("LoadAll")]
        public void LoadAll()
        {
            for(int i = 0; i < _dataList.Count; ++i)
                _loadEvent.Raise(_dataList[i], _loadDataList[i]);
        }


    }
}
