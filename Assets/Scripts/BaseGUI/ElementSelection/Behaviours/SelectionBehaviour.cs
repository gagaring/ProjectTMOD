using System;
using UnityEngine;

namespace VEngine.GUI
{
    public class SelectionBehaviour : MonoBehaviour, ISelectionBehaviour
	{
		[SerializeField] private GameObject _marker;
		[SerializeField] private bool _setDefaultState = true;
		[SerializeField] private bool _defaultState = false;

		private ISelection _selection;

		public ISelection Selection 
		{ 
			get
			{
				if (_selection == null)
					CreateSelection();
				return _selection;
			}
		}

		public void Start()
		{
			CreateSelection();
		}

		private void CreateSelection()
		{
			_selection = new Selection(_marker, _setDefaultState, _defaultState);
		}
	}
}
