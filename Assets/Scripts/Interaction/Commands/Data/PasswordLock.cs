using Sirenix.OdinInspector;
using UnityEngine;

namespace VEngine.Interaction.Command
{
	[CreateAssetMenu(menuName = "SO/Password/PasswordLock")]
	public class PasswordLock : SerializedScriptableObject, IPasswordLock
	{
		[SerializeField] public int Password { get; set; }
		[SerializeField] public bool IsUnlocked { get; set; }
	}
}