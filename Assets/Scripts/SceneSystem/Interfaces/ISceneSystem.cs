using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.SceneSystem
{
	public interface ISceneSystem
	{
		void Load(ISceneData sceneData, ISceneLoadData loadData);
	}
}
