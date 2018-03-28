using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.Beings;

namespace EvalRpgTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestUnitAttaqueKO()
        {
            Unit A = new Unit("test_A");
            Unit B = new Unit("test_B");

            Assert.IsFalse(A.Attack(B));
        }

    }
}
