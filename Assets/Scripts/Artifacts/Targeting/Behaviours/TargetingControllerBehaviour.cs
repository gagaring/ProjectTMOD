using Sirenix.OdinInspector;
using System;
using UnityEngine;
using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.Artifacts
{
    public abstract class TargetingControllerBehaviour : SerializedMonoBehaviour, TargetingController.IData
    {
		[SerializeField] private BoolVariable _isTargetingActive;

        protected ITargetingController _contoller;

		protected abstract ITargetingController CreateController();

		public bool IsTargetingActive
		{
			get => _isTargetingActive.Value;
			set => _isTargetingActive.Value = value;
		}

		private void Awake() => _contoller = CreateController();

		private void Update() => _contoller.Update(Time.deltaTime);

	}
}
