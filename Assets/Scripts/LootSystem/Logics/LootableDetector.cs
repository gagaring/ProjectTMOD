using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.LootSystem
{
    public class LootableDetector : ILootableDetector
    {
        private readonly IData _data;

        public LootableDetector(IData data) => _data = data;

		public void FindLootable()
		{
            Debug.DrawRay(_data.StartPosition, _data.ForwardDirection * _data.Range, Color.red);
            if (Physics.Raycast(_data.StartPosition, _data.ForwardDirection, out var hitInfo, _data.Range, _data.DetectionRaycastLayerMask))
               OnRaycastHit(hitInfo);
            else
                OnLootableNotFound();
        }

		private void OnRaycastHit(RaycastHit hitInfo)
		{
            var lootableBehaviour = hitInfo.collider.GetComponentInParent<ILootableBehaviour>();
            if (lootableBehaviour == null)
                OnLootableNotFound();
            else
                OnLootableFound(lootableBehaviour);
		}

		private void OnLootableFound(ILootableBehaviour lootableBehaviour)
		{
            _data.OnLootableSelected.Raise(lootableBehaviour.Lootable);
        }

		private void OnLootableNotFound()
		{
            _data.OnLootableSelected.Raise(null);
        }

        public interface IData
        {
            LayerMask DetectionRaycastLayerMask { get; }
            float Range { get; }
            Vector3 StartPosition { get; }
            Vector3 ForwardDirection { get; }
            IGameEvent<ILootable> OnLootableSelected { get; }
        }
    }
}
