using UnityEngine;

namespace VEngine.CCTV
{
	public class CCTVSelectableBehaviour : MonoBehaviour, CCTVSelectable.IData, CCTVSelectable.IComponents
	{
		[SerializeField] private GameObject _selectionMarker;

		public bool Selected { set => _selectionMarker.SetActive(value); }

		private CCTVSelectable _selectable;

		public ICCTVSelectable Selectable
		{
			get
			{
				CreateSelectable();
				return _selectable;
			}
		}

		private void CreateSelectable()
		{
			if (_selectable != null)
				return;
			_selectable = new CCTVSelectable(this, this);
		}
	}
}
