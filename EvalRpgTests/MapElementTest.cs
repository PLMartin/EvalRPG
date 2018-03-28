using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.World;
using EvalRpgLib.Exemples;

namespace EvalRpgTests
{
    [TestClass]
    public class MapElementTest
    {

        [TestMethod]
        public void TestMapElementSearchNeighbours_From_Top_Left()
        {
            Map map = new Map(3, 3);

            MapElement element = map[0, 0];

            Assert.IsNull(element.Neighbors[DirectionEnum.North]);
            Assert.IsNull(element.Neighbors[DirectionEnum.West]);
            Assert.IsNotNull(element.Neighbors[DirectionEnum.Est]);
            Assert.IsNotNull(element.Neighbors[DirectionEnum.South]);

            Assert.AreEqual(map[0, 1], element.Neighbors[DirectionEnum.Est]);
            Assert.AreEqual(map[1, 0], element.Neighbors[DirectionEnum.South]);
        }

        [TestMethod]
        public void TestMapElementSearchNeighbours_From_Bottom_Right()
        {
            Map map = new Map(3, 3);

            MapElement element = map[2, 2];

            Assert.IsNotNull(element.Neighbors[DirectionEnum.North]);
            Assert.IsNotNull(element.Neighbors[DirectionEnum.West]);
            Assert.IsNull(element.Neighbors[DirectionEnum.Est]);
            Assert.IsNull(element.Neighbors[DirectionEnum.South]);

            Assert.AreEqual(map[1, 2], element.Neighbors[DirectionEnum.North]);
            Assert.AreEqual(map[2, 1], element.Neighbors[DirectionEnum.West]);
        }

        [TestMethod]
        public void TestMapElementSearchNeighbours_From_Center()
        {
            Map map = new Map(3, 3);

            MapElement element = map[1, 1];

            Assert.IsNotNull(element.Neighbors[DirectionEnum.North]);
            Assert.IsNotNull(element.Neighbors[DirectionEnum.West]);
            Assert.IsNotNull(element.Neighbors[DirectionEnum.Est]);
            Assert.IsNotNull(element.Neighbors[DirectionEnum.South]);

            Assert.AreEqual(map[0, 1], element.Neighbors[DirectionEnum.North]);
            Assert.AreEqual(map[1, 0], element.Neighbors[DirectionEnum.West]);
            Assert.AreEqual(map[1, 2], element.Neighbors[DirectionEnum.Est]);
            Assert.AreEqual(map[2, 1], element.Neighbors[DirectionEnum.South]);
        }

        [TestMethod]
        public void TestMapElementAddContentOK()
        {
            Map map = new Map(3, 3);
            MapElement element = map[1, 1];
            IMapContent content = new Hero("foo");

            element.AddContent(content);

            Assert.IsNotNull(element.ContentList);
            Assert.AreEqual(1, element.ContentList.Count);
            Assert.AreEqual(element, content.Location);

            MapElement otherElement = map[1, 2];
            otherElement.AddContent(content);

            Assert.AreEqual(0, element.ContentList.Count);
            Assert.AreEqual(otherElement, content.Location);
        }

        [TestMethod]
        public void TestMapElementAddContentKO()
        {
            Map map = new Map(3, 3);
            MapElement element = map[1, 1];

            element.AddContent(null);

            Assert.IsNotNull(element.ContentList);
            Assert.AreEqual(0, element.ContentList.Count);
        }
    }
}
