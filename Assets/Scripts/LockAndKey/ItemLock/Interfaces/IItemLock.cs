using VEngine.Enviroment;
using VEngine.Items;

namespace VEngine.LockAndKey
{
	public interface IItemLock : ISwitch
	{
		bool Unlock(IItem item);
		bool CanUnlockWith(IItem item);
	}
}