using System.Collections.Generic;
using UnityEngine;
using VEngine.Log;

namespace VEngine.Anim
{
	public abstract class CAnimatorBase : MonoBehaviour
	{
		[SerializeField] protected Animator _animator;

		private static Dictionary<eTrigger, int> _triggerHashes = new Dictionary<eTrigger, int>();
		private static Dictionary<eBool, int> _boolHashes = new Dictionary<eBool, int>();
		private static Dictionary<eFloat, int> _floatHashes = new Dictionary<eFloat, int>();
		private static Dictionary<eInt, int> _intHashes = new Dictionary<eInt, int>();

		public static int GetHash(eTrigger key) => _triggerHashes[key];
		public static int GetHash(eBool key) => _boolHashes[key];
		public static int GetHash(eFloat key) => _floatHashes[key];
		public static int GetHash(eInt key) => _intHashes[key];

		protected void SetHash(eTrigger key) => _triggerHashes[key] = EnumToHash<eTrigger>(key);
		protected void SetHash(eBool key) => _boolHashes[key] = EnumToHash<eBool>(key);
		protected void SetHash(eFloat key) => _floatHashes[key] = EnumToHash<eFloat>(key);
		protected void SetHash(eInt key) => _intHashes[key] = EnumToHash<eInt>(key);

		protected abstract void RegisterHashes();

		public void Awake()
		{
			RegisterHashes();
		}

		#region Set/Reset
		protected void Set(eTrigger key)
		{
			_animator.SetTrigger(_triggerHashes[key]);
		}

		protected void Reset(eTrigger key)
		{
			_animator.ResetTrigger(_triggerHashes[key]);
		}

		protected void Set(eInt key, int value)
		{
			_animator.SetInteger(GetHash(key), value);
		}

		protected void Set(eBool key, bool value)
		{
			_animator.SetBool(GetHash(key), value);
		}

		protected void Set(eFloat key, float value)
		{
			_animator.SetFloat(GetHash(key), value);
		}
		#endregion

		#region EnumoToHash
		private int EnumToHash(eFloat key)
		{
			//switch (key)
			//{
			//	case eFloat.Speed: return Animator.StringToHash(Consts.SPEED);
			//}

			//VLog.Log(VLog.eFlag.Game, VLog.eLevel.Error, $"Animator controller: Missing enum to string: {key}");
			//return -1;
			return EnumToHash<eFloat>(key);
		}

		private int EnumToHash(eBool key)
		{
			//switch (key)
			//{
			//}

			VLog.Log(VLog.eFlag.Game, VLog.eLevel.Error, $"Animator controller: Missing enum to string: {key}");
			return -1;
		}

		private int EnumToHash(eTrigger key)
		{
			//switch (key)
			//{
			//}

			VLog.Log(VLog.eFlag.Game, VLog.eLevel.Error, $"Animator controller: Missing enum to string: {key}");
			return -1;
		}

		private int EnumToHash(eInt key)
		{
			//switch (key)
			//{
			//}

			VLog.Log(VLog.eFlag.Game, VLog.eLevel.Error, $"Animator controller: Missing enum to string: {key}");
			return -1;
		}

		private int EnumToHash<T>(T enumType) where T : struct, System.IConvertible
		{
			if(!typeof(T).IsEnum)
			{
				VLog.Log(VLog.eFlag.Animation, VLog.eLevel.Error, $"T must be an enumerated type");
			}
			return Animator.StringToHash(enumType.ToString());
		}
		#endregion
	}
}
