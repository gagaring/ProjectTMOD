#if UNITY_EDITOR
using UnityEditor;
using VEngine.SO.Variables;

namespace VTest.SO.Variables
{
    [CustomPropertyDrawer(typeof(SingleUnityLayerReference))]
    public class SingleUnityLayerReferenceDrawer : ReferenceDrawer
    {
    }
}
#endif
