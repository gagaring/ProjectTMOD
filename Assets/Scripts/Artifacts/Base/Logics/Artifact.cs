using UnityEngine;
using VEngine.Items;

namespace VEngine.Artifacts
{
	public class Artifact : IArtifact
	{
		private IData _data;
		private MonoBehaviour _attachedModel;
		protected bool _inited = false;

		public GameObject GameObject => _data.GameObject;
		public IItem Attached { get; set; }

		public string Name => GameObject.name;
		public bool IsActive { get; set; }

		public MonoBehaviour AttachModel
		{
			get => _attachedModel;
			set
			{
				_attachedModel = value;
				SetupAttachModel(value);
			}
		}

		public Vector3 Position 
		{
			get => GameObject.transform.position; 
			set => GameObject.transform.position = value; 
		}

		public Vector3 Forward
		{
			get => GameObject.transform.forward;
			set => GameObject.transform.forward = value;
		}

		public Artifact()
		{
		}

		public Artifact(IData data)
		{
			_data = data;
			_inited = true;
		}

		public virtual bool Init(IData data)
		{
			if (_inited)
				return false;
			_data = data;
			_inited = true;
			return true;
		}

		public void Reset()
		{

		}

		private void SetupAttachModel(MonoBehaviour model)
		{
			model.transform.SetParent(GameObject.transform);
			model.transform.localPosition = Vector3.zero;
			model.transform.localRotation = Quaternion.identity;
			model.gameObject.SetActive(true);
		}

		public virtual T GetComponent<T>() where T : Component => GameObject.GetComponent<T>();

		public interface IData
		{
			GameObject GameObject { get; }
		}
	}
}
