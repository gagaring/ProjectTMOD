using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace VEngine.GUI
{
	public class CutOfMaskImage : Image
	{
		public override Material materialForRendering
		{
			get
			{
				var material = new Material(base.materialForRendering);
				material.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
				return material;
			}
		}
	}
}
