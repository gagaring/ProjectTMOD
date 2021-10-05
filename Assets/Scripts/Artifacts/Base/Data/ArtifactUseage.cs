using Sirenix.OdinInspector;
using System;

namespace VEngine.Artifacts
{
	//[CreateAssetMenu(menuName = "SO/Artifacts/Useage/...")]
	public abstract class ArtifactUseage : SerializedScriptableObject, IArtifactUseage
    {
		public static bool ConvertUseage<T>(IArtifactUseage useage, out T result)
		{
			result = (T)Convert.ChangeType(useage, typeof(T));
			return result != null;
		}
	}
}
