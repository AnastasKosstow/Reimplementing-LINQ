
namespace LINQ_Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using LINQ;

    [TestClass]
    public class Zip_Tests
    {
        [TestMethod]
        public void SumCollections()
        {
            IEnumerable<int> first = System.Linq.Enumerable.Range(1, 5);
            IEnumerable<int> second = System.Linq.Enumerable.Range(1, 5);

            var result = first.Zip(second, (x, y) => x + y).ToArray();
            CollectionAssert.AreEqual(result, new int[] { 2, 4, 6, 8, 10 });
        }

        [TestMethod]
        public void NullCollectionThrowsNullArgumentException()
        {
            IEnumerable<int> first = null;
            IEnumerable<int> second = System.Linq.Enumerable.Range(1, 5);
            Assert.ThrowsException<ArgumentNullException>(() => first.Zip(second, (x, y) => x + y));
        }
    }
}
