using System;
using UnityEngine;

namespace VEngine.SO.Variables
{
    [CreateAssetMenu( menuName = "SO/Variables/SingleUnityLayer")]
	public class SingleUnityLayerVariable : TVariable<SingleUnityLayer>
    {
    }


    [Serializable]
    public class SingleUnityLayerReference : TReferenceWithConstant<SingleUnityLayer, SingleUnityLayerVariable>
    {
    }
}
