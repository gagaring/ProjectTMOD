namespace VEngine.Interaction.Command
{
	public interface IPasswordLock 
	{
		int Password { get; set; }
		bool IsUnlocked { get; set; }
	}
}