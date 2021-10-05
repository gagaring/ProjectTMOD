using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.SceneSystem
{
    [CreateAssetMenu(menuName = "SO/Scene/LoadReadOnlyListGameEvent")]
    public class SceneReadOnlyListLoadingGameEvent : TGameEvent<IReadOnlyList<ISceneData>, ISceneLoadData>
    {
    }
}
