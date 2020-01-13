
namespace LINQ_Tests
{
    using System;
    using System.Collections.Generic;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using LINQ;

    [TestClass]
    public class Concat_Tests
    {
        [TestMethod]
        public void ThrowsException_FirstSequenceIsNull()
        {
            IEnumerable<int> first = null;
            IEnumerable<int> second = new int[] { 5 };
            
            Assert.ThrowsException<ArgumentNullException>(() => first.Concat(second));
        }

        [TestMethod]
        public void ThrowsException_SecondSequenceIsNull()
        {
            IEnumerable<int> first = new int[] { 5 };
            IEnumerable<int> second = null;

            Assert.ThrowsException<ArgumentNullException>(() => first.Concat(second));
        }

        [TestMethod]
        public void FirstAndSecondSequenceAreFine()
        {
            IEnumerable<int> first = new int[] { 5 };
            IEnumerable<int> second = new int[] { 7 };
            
            var query = first.Concat(second);
            
            using (var iterator = query.GetEnumerator())
            {
                Assert.IsNotNull(query);
                Assert.IsTrue(iterator.MoveNext());
                Assert.AreEqual(5, iterator.Current);
                Assert.IsTrue(iterator.MoveNext());
                Assert.AreEqual(7, iterator.Current);
            }
        }
    }
}
