﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tsubaki.CoreLib.Extensions;

namespace Tsubaki.CoreLib.Test
{
    [TestClass]
    public class EnumerableExtensionsTest
    {
        [TestMethod]
        public void ForEachTest()
        {
            var actual = new List<int>();
            var expected = new List<int> { 1, 2, 3, 4, 5 };
            Enumerable.Range(1, 5).ForEach(i => actual.Add(i));
            for (var i = 0; i < 5; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void MergeTest()
        {
            var expected = new List<int> { 1, 2, 3, 4, 5 };
            var actual = Enumerable.Range(1, 3).Merge(Enumerable.Range(4, 2)).ToList();
            for (var i = 0; i < 5; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TopTest()
        {
            var count = 3;
            var data = Enumerable.Range(1, 10).Select(i => new Person { Name = "Tsubaki" + i, Age = i });
            var expected = new List<string> { "Tsubaki10", "Tsubaki9", "Tsubaki8" };
            var actual = data.Top(item => item.Age, count).ToList();
            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(expected[i], actual[i].Name);
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
