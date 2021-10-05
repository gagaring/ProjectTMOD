using Sirenix.OdinInspector;
using UnityEngine;

namespace VEngine.Audio
{
	public class DinamicSFXBehaviour : SerializedMonoBehaviour
	{
		[SerializeField] public AudioSource AudioSource { get; internal set; }
	}
}