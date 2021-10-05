using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using VEngine.Items;
using VEngine.SO.Events;

namespace VTest.Throwables
{
    public class ThrowableGameTest : SerializedMonoBehaviour, IOnItemUsed, ICanUseItem
    {
		[OnValueChanged(nameof(OnItemChanged))]
		[SerializeField] private IItem _item;

		[OnValueChanged(nameof(OnAutomaticeChanged))]
		[SerializeField] private bool _automatice;

		[ShowIf(nameof(_automatice))]
		[SerializeField] private float _autoFirePerSec = 1.0f;

		[SerializeField] private ItemGameEvent _setItem;
		[SerializeField] private bool _fireRaiseValue;
		[SerializeField] private BoolGameEvent _fire;

		private float _timer;

		private void OnAutomaticeChanged()
		{
			_timer = _autoFirePerSec;
		}

		private void OnItemChanged()
		{
			_setItem.Raise(_item);
		}

		private void Awake()
		{
			if (_item != null)
				OnItemChanged();
			_timer = _autoFirePerSec - 1.0f;
		}

		private void Update()
		{
			if (!_automatice)
				return;
			_timer += Time.deltaTime;
			if (_timer > _autoFirePerSec)
			{
				Fire();
				_timer = 0.0f;
			}
		}

		[Button("Fire")]
		[EnableIf("@!this._automatice && UnityEngine.Application.isPlaying && this._item != null")]
		private void Fire()
		{
			if (_item == null)
				return;
			_fire.Raise(_fireRaiseValue);
		}

		public void OnUsed(IItem item)
		{
		}

		public bool CanUse(IItem item)
		{
			return true;
		}
	}
}
