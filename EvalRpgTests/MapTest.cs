using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.World;

namespace EvalRpgTests
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void TestMapGenerateConstructorEmpty()
        {
            Map map = new Map();

            // vérification de la taille
            Assert.AreEqual(Map.WIDTH, map.Matrix.GetLength(1));
            Assert.AreEqual(Map.HEIGHT, map.Matrix.GetLength(0));

            // vérification du contenu
            Assert.IsNotNull(map[2, 2]);
        }

        [TestMethod]
        public void TestMapGenerateConstructorNotEmpty()
        {
            Map map = new Map(5, 6);

            // vérification de la taille
            Assert.AreEqual(5, map.Matrix.GetLength(1));
            Assert.AreEqual(6, map.Matrix.GetLength(0));

            // vérification du contenu
            Assert.IsNotNull(map[2, 2]);
        }

        [TestMethod]
        public void TestMapIndexesInMatrixOK()
        {
            Map map = new Map(5, 10);

            Assert.IsTrue(map.IndexesInMatrix(0, 0));
            Assert.IsTrue(map.IndexesInMatrix(1, 1));
            Assert.IsTrue(map.IndexesInMatrix(1, 4));
            Assert.IsTrue(map.IndexesInMatrix(9, 1));
            Assert.IsTrue(map.IndexesInMatrix(9, 4));
        }

        [TestMethod]
        public void TestMapIndexesInMatrixKO()
        {
            Map map = new Map(5, 10);

            Assert.IsFalse(map.IndexesInMatrix(0, -1));
            Assert.IsFalse(map.IndexesInMatrix(-1, 0));
            Assert.IsFalse(map.IndexesInMatrix(10, 0));
            Assert.IsFalse(map.IndexesInMatrix(0, 5));
            Assert.IsFalse(map.IndexesInMatrix(10, 5));
        }
    }
}
