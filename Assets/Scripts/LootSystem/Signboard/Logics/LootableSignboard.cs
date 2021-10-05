using UnityEngine;
using VEngine.ObjectPool;

namespace VEngine.LootSystem.Signboard
{
	public class LootableSignboard : ILootableSignboard
	{
		private readonly IData _data;
		private LootableBehaviour _attachModel;

		public LootableSignboard(IData data) => _data = data;

		public string Name => _data.Transform.name;
		public Vector3 Position => _data.Transform.position;
		public IObjectPoolEntity LootableEntity => _data.LootableEntity;
		public GameObject GameObject => _data.Transform.gameObject;

		public LootableBehaviour AttachedModel
		{
			get => _attachModel;
			set
			{
				if (_attachModel != null)
					_attachModel.OnCurrentAmountChanged -= OnLootableCurrentAmountChanged;
				_attachModel = value;
				if (value == null)
					return;
				value.CurrentAmount = _data.CurrentAmount;
				_attachModel.OnCurrentAmountChanged += OnLootableCurrentAmountChanged;
				_attachModel.transform.gameObject.SetActive(true);
				_attachModel.transform.SetParent(_data.Transform);
				_attachModel.transform.localPosition = Vector3.zero;
				_attachModel.transform.localRotation = Quaternion.identity;
			}
		}

		public void OnLootableCurrentAmountChanged(uint amount)
		{
			_data.CurrentAmount = amount;
		}

		public interface IData
        {
			IObjectPoolEntity LootableEntity { get; }
			Transform Transform { get; }
			uint CurrentAmount { get; set; }
		}
    }
}
