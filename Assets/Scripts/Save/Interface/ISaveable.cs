namespace VEngine.Save
{
	public interface ISaveable
	{
		eSaveType SaveType { get; }

		object Save();
		void Load(object saveData);
		void LoadDefault();
	}
}

//string path = AssetDatabase.GetAssetPath(this);
//_id = AssetDatabase.AssetPathToGUID(path);