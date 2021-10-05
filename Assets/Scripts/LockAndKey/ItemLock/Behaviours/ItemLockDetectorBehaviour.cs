using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.LockAndKey.Assets.Scripts.LockAndKey.ItemLock.Behaviours
{
	public class ItemLockDetectorBehaviour : MonoBehaviour, ItemLockDetector.IData
	{
		[SerializeField] public ItemLockVariable _currentItemLock;
		
		public IVariable<IItemLock> CurrentItemLock => _currentItemLock;
		
		private IItemLockDetector _detector;

		private void Awake()
		{
			_detector = new ItemLockDetector(this);
		}

		public void OnReached(Collider collider)
		{
			var itemLock = collider.GetComponent<IItemLockBehaviour>();
			if (itemLock == null)
				return;
			_detector.OnItemLockReached(itemLock.Lock);
		}

		public void OnLeft(Collider collider)
		{
			var itemLock = collider.GetComponent<IItemLockBehaviour>();
			if (itemLock == null)
				return;
			_detector.OnItemLockLeft(itemLock.Lock);
		}
	}
}