using System;
using UnityEngine;
using VEngine.CCTV.Events;
using VEngine.Enviroment.Rotate;
using VEngine.SO.Events;

namespace VEngine.CCTV
{
    public class CCTVRotateableBehaviour : MonoBehaviour, CCTVRotateable.IData, CCTVRotateable.IComponents
	{
		[SerializeField] private CCTVSelectableBehaviour _selectable;
		[SerializeField] private RotateBetweenFixesBehaviour _rotateBetweenFixes;
		[Header("Events")]
		[SerializeField] private CCTVRotateableGameEvent _onSelectedEvent;
		
		private CCTVRotateable _rotateable;

		public ICCTVSelectable Selectable => _selectable.Selectable;
		public IGameEvent<ICCTVRotateable> OnRotateableSelectedEvent => _onSelectedEvent;
		public ICCTVRotateable Rotateable => _rotateable;
		public IRotateBetweenFixes RotateBetweenFixes => _rotateBetweenFixes.RotateBetweenFixes;

		private void Awake() => CreateRotateable();

		protected virtual void CreateRotateable() => _rotateable = new CCTVRotateable(this, this);

	}
}
