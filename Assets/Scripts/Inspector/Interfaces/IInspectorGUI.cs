
using VEngine.Items;

namespace VEngine.Inspector.GUI
{
	public interface IInspectorGUI
	{
		void Inspect(IItem item);
		void Open(bool open);
	}
}
