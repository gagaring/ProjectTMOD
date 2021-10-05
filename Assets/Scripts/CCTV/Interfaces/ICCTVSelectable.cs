using System;

namespace VEngine.CCTV
{
	public interface ICCTVSelectable
	{
		bool Selected { set; }
		Action OnSelected { get; set; }
	}
}
