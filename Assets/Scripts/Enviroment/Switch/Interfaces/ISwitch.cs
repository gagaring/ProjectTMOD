using System;

namespace VEngine.Enviroment
{
	public interface ISwitch 
	{
		Action<ISwitch, bool> OnChanged { get; set; }
	}
}