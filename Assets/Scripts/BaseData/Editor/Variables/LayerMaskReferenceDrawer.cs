#if UNITY_EDITOR
using UnityEditor;
using VEngine.SO.Variables;

namespace VTest.SO.Variables
{
    [CustomPropertyDrawer(typeof(LayerMaskReference))]
    public class LayerMaskReferenceDrawer : ReferenceDrawer
    {
    }
}
#endif
