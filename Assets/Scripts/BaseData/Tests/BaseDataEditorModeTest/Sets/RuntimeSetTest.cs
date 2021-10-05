using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using VEngine.SO.Sets;

namespace VTest
{
    public class RuntimeSetTest
    {
        [Test]
        public void check_runtime_count_after_add_items()
        {
            var set = ScriptableObject.CreateInstance<TestFloatRuntimeSet>();
            set.Add(0.5f);
            set.Add(1.0f);
            Assert.AreEqual(set.Items.Count, 2);
        }

        [Test]
        public void check_runtime_count_after_add_and_remove_items()
        {
            var set = ScriptableObject.CreateInstance<TestFloatRuntimeSet>();
            set.Add(0.5f);
            set.Add(1.0f);
            set.Remove(0.5f);
            set.Remove(1.0f);
            Assert.AreEqual(set.Items.Count, 0);
        }

        [Test]
        public void check_runtime_item_after_add_items()
        {
            var set = ScriptableObject.CreateInstance<TestFloatRuntimeSet>();
            set.Add(0.5f);
            set.Add(1.0f);
            Assert.AreEqual(set.Items.Contains(0.5f), true);
        }

        [Test]
        public void check_runtime_item_after_add_items2()
        {
            var set = ScriptableObject.CreateInstance<TestFloatRuntimeSet>();
            set.Add(0.5f);
            set.Add(1.0f);
            Assert.AreEqual(set.Items.Contains(1.0f), true);
        }

        [Test]
        public void check_runtime_item_after_add_items3()
        {
            var set = ScriptableObject.CreateInstance<TestFloatRuntimeSet>();
            set.Add(0.5f);
            set.Add(1.0f);
            Assert.AreEqual(set.Items.Contains(0.0f), false);
        }

        public class TestFloatRuntimeSet : TRuntimeSet<float>
		{
		}
    }
}
