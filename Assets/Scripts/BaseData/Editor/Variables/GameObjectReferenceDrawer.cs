#if UNITY_EDITOR
using UnityEditor;
using VEngine.SO.Variables;

namespace VTest.SO.Variables
{
    [CustomPropertyDrawer(typeof(GameObjectReference))]
    public class GameObjectReferenceDrawer : ReferenceDrawer
    {
    }
}
#endif
