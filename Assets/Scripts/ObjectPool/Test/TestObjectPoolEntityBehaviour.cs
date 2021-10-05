using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.ObjectPool
{
    public class TestObjectPoolEntityBehaviour : MonoBehaviour
    {
		private static int _globalIndex = 0;
		private int _index = 0;

        public void Hello()
		{
			Debug.LogError($"{++_globalIndex} - {++_index}");
		}
	}
}
