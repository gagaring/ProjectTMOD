using UnityEngine;

namespace VEngine.Enviroment.Switch
{
	public class ChangeColorOnActivate : MonoBehaviour
	{
		[SerializeField] private TriggerSwitchBehaviour _switch;
		[SerializeField] private Renderer _renderer;
		[SerializeField] private Color _activateColor = Color.green;
		[SerializeField] private Color _deactivateColor = Color.red;

		private void Awake()
		{
			_switch.OnChanged += OnSwitchChanged;
			OnSwitchChanged(false);
		}

		private void OnSwitchChanged(ISwitch arg1, bool activate) => OnSwitchChanged(activate);
		private void OnSwitchChanged(bool activate) => _renderer.material.color = activate ? _activateColor : _deactivateColor;
	}
}