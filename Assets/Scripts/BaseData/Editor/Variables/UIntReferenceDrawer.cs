#if UNITY_EDITOR
using UnityEditor;
using VEngine.SO.Variables;

namespace VTest.SO.Variables
{
    [CustomPropertyDrawer(typeof(UIntReference))]
    public class UIntReferenceDrawer : ReferenceDrawer
    {
    }
}
#endif
