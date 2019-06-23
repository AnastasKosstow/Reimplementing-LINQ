
namespace LINQ_Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using LINQ;

    [TestClass]
    public class Where_Tests
    {
        [TestMethod]
        public void Filtering()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = source.Where(x => x < 4);
            CollectionAssert.AreEqual(result.ToArray(), new int[] { 1, 3, 2, 1 });
        }

        [TestMethod]
        public void QueryFiltering()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = from x in source
                         where x < 4
                         select x;
            CollectionAssert.AreEqual(result.ToArray(), new int[] { 1, 3, 2, 1 });
        }

        [TestMethod]
        public void NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.ThrowsException<ArgumentNullException>(() => source.Where(x => x > 5));
        }

        [TestMethod]
        public void NullPredicateThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, bool> predicate = null;
            Assert.ThrowsException<ArgumentNullException>(() => source.Where(predicate));
        }
    }
}
