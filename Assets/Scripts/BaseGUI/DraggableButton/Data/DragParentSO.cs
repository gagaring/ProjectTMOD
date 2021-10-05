using System;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.GUI.Draggable
{
	[CreateAssetMenu(menuName = "SO/GUI/DragParent")]
	public class DragParentSO : TVariable<Transform>
	{
	}

	[Serializable]
	public class DragParentReference : TReferenceWithConstant<Transform, DragParentSO>
	{

	}
}
