using System.Collections.Generic;

namespace VEngine.SceneSystem
{
	public interface ISceneDataList
	{
		IReadOnlyList<ISceneData> List { get; }
	}
}