using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VEditor.Items.Creator
{
    public class ItemCreatorEditorWindow : OdinEditorWindow
    {
        [MenuItem("Tools/ItemCreator")]
        private static void OpenWindow()
		{
            GetWindow<ItemCreatorEditorWindow>().Show();
		}
    }
}
