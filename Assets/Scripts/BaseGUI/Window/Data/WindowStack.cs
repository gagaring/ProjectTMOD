using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Log;

namespace VEngine.GUI
{
	[CreateAssetMenu(menuName = "SO/BaseGUI/WindowStack")]
	public class WindowStack : SerializedScriptableObject, IWindowStack
	{
		[ReadOnly] [SerializeField] private LinkedList<IWindow> _windows = new LinkedList<IWindow>();

		public int OpenWindowCount => _windows.Count;
		public bool IsEmpty => OpenWindowCount == 0;

		public void Add(IWindow window)
		{
			VLog.Log(VLog.eFlag.GUI, VLog.eLevel.Normal, $"Window added to WindowStack: {window.Name}");
			_windows.AddLast(window);
		}

		public void Clear() => _windows.Clear();

		public IWindow Peek() => _windows.Last.Value;

		public void Remove(IWindow window)
		{
			for(var node = _windows.Last;  node != null; )
			{
				if(node.Value == window)
				{
					_windows.Remove(node);
					VLog.Log(VLog.eFlag.GUI, VLog.eLevel.Normal, $"Window removed from WindowStack: {window.Name}");
					return;
				}
				node = node.Previous;
			}
			VLog.Log(VLog.eFlag.GUI, VLog.eLevel.Normal, $"WindowStack - remove: Can't find window: {window.Name}");
		}
	}

	[Serializable]
    public class WindowStackReference
	{
        [SerializeField] private WindowStack _windowStack;

        public IWindowStack Stack => _windowStack;
	}
}
