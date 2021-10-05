#if UNITY_EDITOR
using UnityEditor;
using VEngine.SO.Variables;

namespace VTest.SO.Variables
{
    [CustomPropertyDrawer(typeof(FontReference))]
    public class FontReferenceDrawer : ReferenceDrawer
    {
    }
}
#endif
