using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Artifacts;

namespace VEngine.Explosions
{
	[CreateAssetMenu(menuName = "SO/Artifacts/Useage/Commands/Explosion/ExplosionData")]
	public class ExplosionData : SerializedScriptableObject, IExplosionData
	{
		[SerializeField] private List<IArtifactCommand> _commands = new List<IArtifactCommand>();

		public IReadOnlyList<IArtifactCommand> Commands => _commands;
	}
}