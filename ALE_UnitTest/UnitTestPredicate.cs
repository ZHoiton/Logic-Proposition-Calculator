using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE1_test;

namespace ALE_UnitTest
{
    [TestClass]
    public class UnitTestPredicate
    {
        [TestMethod]
        public void consumeTest()
        {
            Predicate predicate = new Predicate("a");
            Assert.AreEqual("a", predicate.getPredicateASCIIFormat());
        }
        [TestMethod]
        public void consumeNOTTest()
        {
            Predicate predicate = new Predicate("~(a)");
            Assert.AreEqual("~(a)", predicate.getPredicateASCIIFormat());
        }
        [TestMethod]
        public void calculateTest()
        {
            Predicate predicate = new Predicate("1");
            Assert.AreEqual(true, predicate.getValue());
        }
        [TestMethod]
        public void calculateNOTTest()
        {
            Predicate predicate = new Predicate("~(1)");
            Assert.AreEqual(false, predicate.getValue());
        }
        [TestMethod]
        public void calculateNOTSecondTest()
        {
            Predicate predicate = new Predicate("~(0)");
            Assert.AreEqual(true, predicate.getValue());
        }
    }
}
