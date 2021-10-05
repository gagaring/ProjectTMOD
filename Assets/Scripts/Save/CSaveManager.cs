using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

namespace VEngine.Save
{
	public class CSaveManager : ISaveManager
	{
		private Dictionary<eSaveType, ISaveable> _saveables = new Dictionary<eSaveType, ISaveable>();

		private CSavePath _savePath;

		public CSaveManager(CSavePath path)
		{
			_savePath = path;
		}

		public void AddSaveable(ISaveable saveable)
		{
			_saveables[saveable.SaveType] = saveable;
		}

		public void RemoveSaveable(ISaveable saveable)
		{
			_saveables.Remove(saveable.SaveType);
		}

		#region Load
		public void Load(eSaveType saveType = eSaveType.All)
		{
			if (saveType == eSaveType.All)
			{
				LoadAll();
				return;
			}
			if (LoadData(saveType, out var save))
			{
				_saveables[saveType].Load(save);
			}
			else
			{
				_saveables[saveType].LoadDefault();
			}
		}

		private void LoadAll()
		{
			foreach (var curr in _saveables)
			{
				Load(curr.Value.SaveType);
			}
		}

		public bool LoadData(eSaveType type, out object save)
		{
			return LoadFile(_savePath.GetPath(type), out save);
		}

		private bool LoadFile(string path, out object save)
		{
			if(!OpenFile(out var file, path))
			{
				save = null;
				return false;
			}
			if (file.Length == 0)
			{
				file.Close();
				save = null;
				return false;
			}
			BinaryFormatter bf = new BinaryFormatter();
			save = bf.Deserialize(file);
			file.Close();
			return true;
		}
		#endregion

		#region Save
		public void Save(eSaveType saveType = eSaveType.All)
		{
			if (saveType == eSaveType.All)
			{
				SaveAll();
				return;
			}
			var save = _saveables[saveType].Save();
			Save(saveType, save);
		}

		private void Save(eSaveType saveType, object save)
		{
			Save(_savePath.GetPath(saveType), save);
		}

		private void Save(string path, object save)
		{
			BinaryFormatter bf = new BinaryFormatter();
			if (!OpenFile(out var file, path))
			{
				file = File.Create(Application.persistentDataPath + "/" + path);
			}
			bf.Serialize(file, save);
			file.Close();
		}

		private void SaveAll()
		{
			foreach (var curr in _saveables)
				Save(curr.Value.SaveType);
		}

		private bool OpenFile(out FileStream file, string path)
		{
			var fullPath = Application.persistentDataPath + "/" + path;
			if (!File.Exists(fullPath))
			{
				file = null;
				return false;
			}
			file = File.Open(fullPath, FileMode.Open);
			return true;
		}
		#endregion
	}
}