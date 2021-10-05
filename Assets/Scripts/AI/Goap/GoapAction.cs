using UnityEngine;
using System.Collections.Generic;

namespace VEngine.AI.Goap
{
	public abstract class GoapAction : MonoBehaviour
	{
		#region members
		[SerializeField] private string _name = "No Name";
		[SerializeField] private float _cost = 1f;
		[SerializeField] private float _speed;

		protected bool _isPerformDone = false;
		#endregion

		#region properties
		public string Name { get { return _name; } }
		public GameObject Target { get; protected set; }
		public float Cost { get { return _cost; } }
		public float Speed { get { return _speed; } }

		public HashSet<KeyValuePair<eGoapEffects, object>> Preconditions { get; private set; }
		public HashSet<KeyValuePair<eGoapEffects, object>> Effects { get; private set; }
		public bool InRange { get; set; }
		#endregion

		public abstract bool IsDone();
		public abstract bool CheckProceduralPrecondition(GameObject agent);
		public abstract bool Perform(GameObject agent);
		public abstract bool RequiresInRange();
		public abstract void OnMove();

		public GoapAction()
		{
			Preconditions = new HashSet<KeyValuePair<eGoapEffects, object>>();
			Effects = new HashSet<KeyValuePair<eGoapEffects, object>>();
		}

		public void DoReset()
		{
			InRange = false;
			ResetAction();
		}

		public virtual void ResetAction()
		{
			_isPerformDone = false;
		}

		public void AddPrecondition(eGoapEffects key, object value)
		{
			Preconditions.Add(new KeyValuePair<eGoapEffects, object>(key, value));
		}

		public void RemovePrecondition(eGoapEffects key)
		{
			RemoveElementByGoapEffectKey(key, Preconditions);
		}

		public void AddEffect(eGoapEffects key, object value)
		{
			Effects.Add(new KeyValuePair<eGoapEffects, object>(key, value));
		}

		public void RemoveEffect(eGoapEffects key)
		{
			RemoveElementByGoapEffectKey(key, Effects);
		}

		private void RemoveElementByGoapEffectKey(eGoapEffects key, HashSet<KeyValuePair<eGoapEffects, object>> hashSet)
		{
			KeyValuePair<eGoapEffects, object> remove = default;
			foreach (var kvp in hashSet)
			{
				if (!kvp.Key.Equals(key))
					continue;
				remove = kvp;
			}
			if (!default(KeyValuePair<eGoapEffects, object>).Equals(remove))
				hashSet.Remove(remove);
		}
	}
}
