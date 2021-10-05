
namespace VEngine.AI.Senses.Sensors.Sight
{
	public class SightTarget : TargetBase
	{
		public virtual bool IsHided { get => false; set => _ = value; }

		protected override void OnTargetedChanged(bool targeted)
		{
		}
	}
}
