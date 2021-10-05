using System.Collections.Generic;
using VEngine.GUI.Context;

namespace VEngine.Inventory.GUI.Context
{
	public class InventoryContextMenu : ContextMenu, IInventoryContextMenu
	{
		private readonly IInventoryContextMenuData _data;
		private readonly IInventoryContextMenuComponents _components;

		public InventoryContextMenu(IInventoryContextMenuData data, IInventoryContextMenuComponents components) : base(data.Base, components.Base)
		{
			_data = data;
			_components = components;
		}

		public void Open(UnityEngine.Vector2 anchorPosition, IInventoryItemGUI itemGUI)
		{
			var activeCommands = GetActiveCommands(itemGUI);
			Open(anchorPosition, GetTexts(activeCommands, itemGUI), null, (index) =>
			{
				activeCommands[index].Action(itemGUI);
				Close();
			}	
			);
		}

		private List<IItemCommand> GetActiveCommands(IInventoryItemGUI itemGUI)
		{
			var activeCommands = new List<IItemCommand>();
			for(int i = 0; i < _data.Commands.Count; ++i)
			{
				if (!_data.Commands[i].Active(itemGUI))
					continue;
				activeCommands.Add(_data.Commands[i]);
			}
			return activeCommands;
		}

		private List<IContextMenuElementData> GetTexts(List<IItemCommand> commands, IInventoryItemGUI itemGUI)
		{
			var list = new List<IContextMenuElementData>();
			for (int i = 0; i < commands.Count; ++i)
			{
				IContextMenuElementData data = new ContextMenuElementData(commands[i].Text, commands[i].Enabled(itemGUI));
				list.Add(data);
			}
			return list;
		}

		private class ContextMenuElementData : IContextMenuElementData
		{
			public string Text { get; private set; }
			public bool Enabled { get; private set; }

			public ContextMenuElementData(string text, bool enabled)
			{
				Text = text;
				Enabled = enabled;
			}
		}

		public interface IInventoryContextMenuComponents
		{
			IComponents Base { get; }
		}

		public interface IInventoryContextMenuData
		{
			IData Base{ get; }
			IReadOnlyList<IItemCommand> Commands { get; }
		}
	}
}
