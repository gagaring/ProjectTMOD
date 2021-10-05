namespace VEngine.LockAndKey
{
	public interface IItemLockDetector 
	{
		void OnItemLockReached(IItemLock itemLock);
		void OnItemLockLeft(IItemLock itemLock);
	}
}