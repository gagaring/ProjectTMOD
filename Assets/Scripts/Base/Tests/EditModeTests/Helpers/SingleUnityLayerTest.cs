using NUnit.Framework;
using UnityEngine;
using VEngine;

namespace VTest
{
	class SingleUnityLayerTest
    {
        [Test]
        public void singleLayer_value_set_to_0()
        {
            //Default: 0
            var variable = new SingleUnityLayer();
            variable.Set(0);
            Assert.AreEqual(variable.LayerIndex, LayerMask.NameToLayer("Default"));
            Assert.AreEqual(variable.Mask, LayerMask.GetMask("Default"));
        }

        [Test]
        public void singleLayer_value_set_to_1()
        {
            //TransparentFX: 1
            var variable = new SingleUnityLayer();
            variable.Set(1);
            Assert.AreEqual(variable.LayerIndex, LayerMask.NameToLayer("TransparentFX"));
            Assert.AreEqual(variable.Mask, LayerMask.GetMask("TransparentFX"));
        }

        [Test]
        public void singleLayer_value_set_to_2()
        {
            //Ignore Raycast: 2
            var variable = new SingleUnityLayer();
            variable.Set(2);
            Assert.AreEqual(variable.LayerIndex, LayerMask.NameToLayer("Ignore Raycast"));
            Assert.AreEqual(variable.Mask, LayerMask.GetMask("Ignore Raycast"));
        }

        [Test]
        public void singleLayer_value_set_to_4()
        {
            //Water: 4
            var variable = new SingleUnityLayer();
            variable.Set(4);
            Assert.AreEqual(variable.LayerIndex, LayerMask.NameToLayer("Water"));
            Assert.AreEqual(variable.Mask, LayerMask.GetMask("Water"));
        }

        [Test]
        public void singleLayer_value_set_to_5()
        {
            //UI: 5
            var variable = new SingleUnityLayer();
            variable.Set(5);
            Assert.AreEqual(variable.LayerIndex, LayerMask.NameToLayer("UI"));
            Assert.AreEqual(variable.Mask, LayerMask.GetMask("UI"));
        }
    }
}
