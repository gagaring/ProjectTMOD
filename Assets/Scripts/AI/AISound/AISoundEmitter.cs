using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Game.Player.AISound
{
	public enum eAISoundType
	{
		None,
		Crouch,
		Walk,
		Sprint
	}

	public class AISoundEmitter : MonoBehaviour
	{
		[SerializeField] private List<AISoundTarget> _targets;

		private AISoundTarget _currentTarget;
		private eAISoundType _type = eAISoundType.None;

		private eAISoundType SoundType
		{
			get => _type;
			set
			{
				_type = value;
				OnTypeChanged();
			}
		}

		private void OnTypeChanged()
		{
			_currentTarget?.Activate(false);
			var target = _targets.Find(x => x.Type == SoundType);
			target?.Activate(true);
			_currentTarget = target;
		}

		public void OnCrouch()
		{

		}

		public void OnSprint()
		{

		}
	}
}
