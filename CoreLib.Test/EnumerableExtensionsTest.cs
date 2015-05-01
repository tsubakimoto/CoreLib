using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tsubaki.CoreLib;

namespace Tsubaki.CoreLib.Test
{
    [TestClass]
    public class EnumerableExtensionsTest
    {
        [TestMethod]
        public void ForEach()
        {
            var actual = new List<int>();
            var expected = new List<int> { 1, 2, 3, 4, 5 };
            Enumerable.Range(1, 5).ForEach(i => actual.Add(i));
            for (var i = 0; i < 5; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
