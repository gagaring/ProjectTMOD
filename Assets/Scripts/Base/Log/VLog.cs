using System;
using UnityEngine;

namespace VEngine.Log
{
	public static class VLog
	{
		#region enums
		public enum eLevel
		{
			None = 0,
			Editor = 1,
			Normal = 2,
			Warning = 3,
			Error = 4,
		}

		public enum eFlag
		{
			Common = 1 << 0,
			Game = 1 << 1,
			GUI = 1 << 2,
			ErrorLog = 1 << 3,
			Localization = 1 << 4,
			AI = 1 << 5,
			Input = 1 << 6,
			Scene = 1 << 7,
			Interaction = 1 << 8,
			Event = 1 << 9,
			Animation = 1 << 10,
			Sound = 1 << 11,
			Loot = 1 << 2,
			Test = 1 << 15
		}
		#endregion

		public static void Log(eFlag flag, eLevel level, string message, GameObject gameObject = null)
		{
			if (flag == eFlag.Event)
				return;
			if (level <= eLevel.Normal)
				Debug.Log(flag + ": " + message, gameObject);
			else if (level <= eLevel.Warning)
				Debug.LogWarning(flag + ": " + message, gameObject);
			else
				Debug.LogError(flag + ": " + message, gameObject);

		}
	}
}
