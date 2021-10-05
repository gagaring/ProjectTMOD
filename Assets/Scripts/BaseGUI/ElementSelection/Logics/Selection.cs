using UnityEngine;

namespace VEngine.GUI
{
	public class Selection : ISelection
	{
		private readonly GameObject _marker;

		private bool _selected;

		public Selection(GameObject marker, bool setDefaultState, bool defaultState)
		{
			_marker = marker;
			if(setDefaultState)
				IsSelected = defaultState;
		}

		public bool IsSelected
		{
			get => _selected;
			set
			{
				_selected = value;
				_marker.SetActive(value);
			}
		}
	}
}
