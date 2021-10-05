using System;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Items
{
	[Serializable]
	public class Details : IDetails
	{
		[SerializeField] private StringReference _name;
		[SerializeField] private StringReference _description;

		public string Name => _name.Value;
		public string Description => _description.Value;
	}
}
