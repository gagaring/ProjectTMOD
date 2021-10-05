using UnityEngine;
using System;
using System.Collections.Generic;

namespace VEngine.Save
{
	[CreateAssetMenu(fileName = "SavePath", menuName = "Save")]
	public class CSavePath : ScriptableObject
	{
		[SerializeField] private List<SSavePath> _savePaths;

		public string GetPath(eSaveType saveType)
		{
			return _savePaths.Find((x)=>x.Type == saveType).Path;
		}

		[Serializable]
		public struct SSavePath
		{
			public eSaveType Type;
			public string Path;
		}
	}

}
