using System.Collections.Generic;

namespace VEngine.Input
{
	public interface IInputStack 
	{
		void Clear();
		int Activate(IReadOnlyList<InputEnabledWithOnChangeEvent> active);
		void Deactivate(int hash);
	}
}
