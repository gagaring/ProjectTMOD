using System;

namespace VEngine.CCTV.GUI
{
	public interface ICCTVGUIControlPanel<T>
	{
		public void Open(T t);
		public void Close();
	}
}
