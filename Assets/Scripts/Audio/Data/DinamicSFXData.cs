using Sirenix.OdinInspector;
using UnityEngine;

namespace VEngine.Audio
{
	[CreateAssetMenu(menuName = "SO/Audio/DinamicSFXData")]
	public class DinamicSFXData : SerializedScriptableObject, IDinamicSFXData
	{
		[SerializeField] public DinamicSFXBehaviour Prefab { get; private set; }
	}
}
