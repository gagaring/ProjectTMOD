﻿#if UNITY_EDITOR
using UnityEditor;
using VEngine.SO.Variables;

namespace VTest.SO.Variables
{
    [CustomPropertyDrawer(typeof(ColorReference))]
    public class ColorReferenceDrawer : ReferenceDrawer
    {
    }
}
#endif
