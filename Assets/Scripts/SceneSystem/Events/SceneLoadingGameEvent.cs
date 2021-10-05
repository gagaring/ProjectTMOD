using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.SceneSystem
{
    [CreateAssetMenu(menuName = "SO/Scene/LoadGameEvent")]
    public class SceneLoadingGameEvent : TGameEvent<ISceneData, ISceneLoadData>
    {
    }
}
