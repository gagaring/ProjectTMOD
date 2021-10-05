using UnityEngine;
using VEngine.Audio;

namespace VEngine.Artifacts
{
	[CreateAssetMenu(menuName = "SO/Artifacts/Data/Command/DinamicSFXArtifactCommand")]
	public class DinamicSFXArtifactCommand : ArtifactCommand
	{
		[SerializeField] private IDinamicSFXSystem _system;
		[SerializeField] private IDinamicSFXData _data;

		public override void Use(IArtifact artifact)
		{
			_system.PlaySfx(_data);
		}
	}
}