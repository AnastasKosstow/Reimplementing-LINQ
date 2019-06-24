
namespace LINQ_Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using LINQ;

    [TestClass]
    public class Select_Tests
    {
        [TestMethod]
        public void Projection()
        {
            string[] source = { "1", "2", "3" };
            var result = source.Select(x => int.Parse(x));
            CollectionAssert.AreEqual(result.ToArray(), new int[] { 1, 2, 3 });
        }

        [TestMethod]
        public void WhereAndSelect()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = from x in source
                         where x < 4
                         select x * 2;
            CollectionAssert.AreEqual(result.ToArray(), new int[] { 2, 6, 4, 2 });
        }

        [TestMethod]
        public void NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.ThrowsException<ArgumentNullException>(() => source.Select(x => x.ToString()));
        }

        [TestMethod]
        public void NullFuncThrowsNullArgumentException()
        {
            string[] source = { "1", "2", "3" };
            Func<string, int> func = null;
            Assert.ThrowsException<ArgumentNullException>(() => source.Select(func));
        }
    }
}
