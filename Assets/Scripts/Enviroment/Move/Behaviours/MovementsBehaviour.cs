using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Enviroment.Move
{
	public class MovementsBehaviour : MonoBehaviour, Movements.IData
	{
		[SerializeField] private List<LinearMove> _moveables;
		[DisableIf("@UnityEngine.Application.isPlaying")]
		[SerializeField] private bool _currentStateOpen;

		private Movements _logic;

		public bool CurrentStateOpen { get => _currentStateOpen; set => _currentStateOpen = value; }
		public IReadOnlyList<IMovement> Moveables => _moveables;

		public bool Enabled { set => enabled = true; }

		public IMovements Movements
		{
			get
			{
				CreateMovements();
				return _logic;
			}
		}

		private void CreateMovements()
		{
			if (_logic != null)
				return;
			_logic = new Movements(this);
		}

		public void SetDirection(bool open)
		{
			Movements.SetDirection(open);
		}

		private void Update()
		{
			Movements.Do(Time.deltaTime);
			if (!_logic.IsFinished)
				return;
			enabled = false;
		}
	}
}