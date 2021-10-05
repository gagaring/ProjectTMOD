using UnityEngine;
using VEngine.SO.Variables;
using VEngine.Game.SO.Speed;

namespace VEngine.Player
{
	public class PlayerSpeeder : MonoBehaviour
	{
		[SerializeField] private SpeedVariable _speed;

		[SerializeField] private FloatReference _crouchSpeed;
		[SerializeField] private FloatReference _walkSpeed;
		[SerializeField] private FloatReference _sprintSpeed;

		private void Start()
		{
			OnStandUp();
		}

		public void OnCrouch()
		{
			SetSpeed(_crouchSpeed.Value);
		}

		public void OnStandUp()
		{
			SetSpeed(_walkSpeed.Value);
		}

		public void OnSprint()
		{
			SetSpeed(_sprintSpeed.Value);
		}

		private void SetSpeed(float multiplier)
		{
			_speed.Value = multiplier * _speed.Max;
		}
	}
}
