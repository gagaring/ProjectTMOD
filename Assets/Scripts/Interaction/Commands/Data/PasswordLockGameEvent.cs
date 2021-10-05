using System.Collections;
using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Interaction.Command
{
	[CreateAssetMenu(menuName = "SO/Password/PasswordLockGameEvent")]
	public class PasswordLockGameEvent : TGameEvent<IPasswordLock>
	{
	}
}