namespace VEngine.Save
{
	public enum eSaveType
	{
		All = 0,
		Progress,
		Achievement,
		Inventory,
	}

	public interface ISaveManager
	{
		void AddSaveable(ISaveable saveable);
		void RemoveSaveable(ISaveable saveable);

		void Save(eSaveType saveType = eSaveType.All);
		void Load(eSaveType saveType = eSaveType.All);
	}
}
