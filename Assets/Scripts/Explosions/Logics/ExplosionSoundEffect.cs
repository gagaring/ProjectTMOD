using UnityEngine;
using VEngine.Artifacts;

namespace VEngine.Explosions
{
	public class ExplosionSoundEffect 
	{
		private IData _data;

		public void Init(IData data)
		{
			_data = data;
		}

		public void Use(IArtifact artifact)
		{
			_data.Source.Play();
		}

		public interface IData
		{
			GameObject GameObject { get; }
			AudioSource Source { get; }
		}
	}
}
