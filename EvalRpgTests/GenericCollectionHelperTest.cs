using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.Helpers;

namespace EvalRpgTests
{
    [TestClass]
    public class GenericCollectionHelperTest
    {

        [TestMethod]
        public void TestCollectionHelperForEachWithIndexes()
        {
            int counter = 0;
            int[,] tab = new int[3, 6];
            tab.ForEachWithIndexes((i, j) =>
            {
                Assert.IsTrue(i >= 0 && i <= 2);
                Assert.IsFalse(i < 0 && i > 2);
                Assert.IsTrue(j >= 0 && j <= 5);
                Assert.IsFalse(j < 0 && j > 5);
                counter++;
            });
            Assert.AreEqual(18, counter);
        }

        [TestMethod]
        public void TestCollectionHelperForEachWithElement()
        {
            int counter = 0;
            int[,] tab = new int[,] {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 },
            };
            tab.ForEachWithElement(x =>
            {
                Assert.IsTrue(x >= 1 && x <= 9);
                Assert.IsFalse(x < 1 && x > 9);
                counter++;
            });
            Assert.AreEqual(9, counter);
        }

    }
}
