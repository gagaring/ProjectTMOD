using System;
using System.Collections.Generic;
using UnityEngine.UI;
using VEngine.Inventory;
using VEngine.Log;

namespace VEngine.Equipments.GUI
{
	public class EquipmentInHandGUI
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public EquipmentInHandGUI(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			OnActiveHandSlotChanged(-1);
		}

		public void OnActiveHandSlotChanged(int index)
		{
			VLog.Log(VLog.eFlag.Game, VLog.eLevel.None, $"ActiveHandSlotVisualizerGUI -OnActiveHandSlotChanged: {index}");
			for (int i = 0; i < _components.Avatars.Count; ++i)
				SetAlpha(_components.Avatars[i], i == index ? _data.ActiveAlpha : _data.DeactiveAlpha);
		}

		private void SetAlpha(Image image, float alpha)
		{
			var color = image.color;
			color.a = alpha;
			image.color = color;
		}

		public interface IData
		{
			float ActiveAlpha { get; }
			float DeactiveAlpha { get; }
		}

		public interface IComponents
		{
			IReadOnlyList<Image> Avatars { get; }
		}
	}
}
