using System.Collections.Generic;
using VEngine.Artifacts;

namespace VEngine.Explosions
{
	public interface IExplosionData
	{
		IReadOnlyList<IArtifactCommand> Commands { get; }
	}
}
