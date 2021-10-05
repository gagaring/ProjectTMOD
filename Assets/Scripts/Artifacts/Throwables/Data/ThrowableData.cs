using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Artifacts.Throwables
{
	[CreateAssetMenu( menuName = "SO/Artifacts/ThrowableData")]
	public class ThrowableData : ScriptableObject, IThrowableData
	{
		[SerializeField] private FloatReference _mass;

		public float Mass => _mass.Value;
		//A trajection miatt 0-nak kell lennie!
		public float Drag => 0;
	}
}
