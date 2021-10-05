using UnityEngine;
using VEngine.Items;

namespace VEngine.Artifacts
{
	public interface IArtifact
	{
		string Name { get; }
		IItem Attached { get; set; }
		void Reset();
		T GetComponent<T>() where T : Component;
		MonoBehaviour AttachModel { get; set; }

		//TODO nem tetszik, hogy van ilyen, de pillanatnyialg az OP miatt kell
		bool IsActive { get; set; }

		//TODO ez sem tetszik
		Vector3 Position { get; set; }
		Vector3 Forward { get; set; }
	}
}
