using UnityEngine;

namespace VEngine.Artifacts.Throwables
{
	[CreateAssetMenu(menuName = "SO/Artifacts/Useage/Throwable")]
	public class ThrowableArtifactUseage : ArtifactUseage
	{
		[SerializeField] private ThrowableData _data;

		public IThrowableData Data => _data;
	}
}
