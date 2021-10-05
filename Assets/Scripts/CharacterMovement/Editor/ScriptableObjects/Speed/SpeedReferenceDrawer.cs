#if UNITY_EDITOR
using UnityEditor;
using VTest.SO.Variables;
using VEngine.Game.SO.Speed;

namespace VEditor.Game.SO.Variables
{
	[CustomPropertyDrawer(typeof(SpeedReference))]
	public class SpeedReferenceDrawer : ReferenceDrawer
    {
    }
}
#endif
