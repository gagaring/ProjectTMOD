using System;

namespace VEngine.GUI.Split
{
	public interface ISplitSlider : IWindow
	{
		void Open(uint minValue, uint maxValue, Action cancelCallback, Action<uint> okCallback);
		uint MinValue { get; }
		uint MaxValue { get; }
		uint CurrentValue { get; }
	}
}
