using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.GUI.Context
{
    public interface IContextMenu
    {
        void Open(Vector2 position, List<IContextMenuElementData> menu, Action canceled, Action<int> ok);
        void Close();

    }

    public interface IContextMenuElementData
    {
        string Text { get; }
        bool Enabled { get; }
    }
}
