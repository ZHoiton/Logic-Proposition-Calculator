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
        public void consumeUpperTest()
        {
            Predicate predicate = new Predicate("A");
            Assert.AreEqual("A", predicate.getPredicateASCIIFormat());
        }
        [TestMethod]
        public void consumeNOTTest()
        {
            Predicate predicate = new Predicate("~(a)");
            Assert.AreEqual("~(a)", predicate.getPredicateASCIIFormat());
        }

        [TestMethod]
        public void consumeNOTUpperTest()
        {
            Predicate predicate = new Predicate("~(Q)");
            Assert.AreEqual("~(Q)", predicate.getPredicateASCIIFormat());
        }
        [TestMethod]
        public void calculateTest()
        {
            Predicate predicate = new Predicate("1");
            Assert.AreEqual(true, predicate.getValue());
        }

        [TestMethod]
        public void calculateFalseTest()
        {
            Predicate predicate = new Predicate("0");
            Assert.AreEqual(false, predicate.getValue());
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
