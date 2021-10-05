using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.SceneSystem
{
    [CreateAssetMenu(menuName = "SO/Scene/LoadListGameEvent")]
    public class SceneListLoadingGameEvent : TGameEvent<ISceneDataList, ISceneLoadData>
    {
    }
}
