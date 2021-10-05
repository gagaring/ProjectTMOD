#if UNITY_EDITOR
using UnityEditor;
using VEngine.GUI.Draggable;
using VTest.SO.Variables;

namespace VTest.GUI.Draggable
{
    [CustomPropertyDrawer(typeof(DragParentReference))]
    public class DragParentReferenceDrawer : ReferenceDrawer
    {
    }
}
#endif
