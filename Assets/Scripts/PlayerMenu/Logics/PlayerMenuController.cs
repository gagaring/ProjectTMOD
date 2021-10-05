using System.Collections;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.PlayerMenu
{
	public class PlayerMenuController 
	{

		public interface IData
		{
			IPlayerMenu PlayerMenu { get; }
			BoolVariableWithOnChangeEvent PlayerMenuInputEnabled { get; }
		}
	}
}