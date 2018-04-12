using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE1_test;

namespace ALE_UnitTest
{
    [TestClass]
    public class UnitTestProposition
    {
        [TestMethod]
        public void doesItConsumePropsCorrectlyTest()
        {
            Proposition proposition = new Proposition("|(=(>(d,B),>(s,B)),=(>(c,B),>(s,g)))");
            string expected_proposition = "|(=(>(d,B),>(s,B)),=(>(c,B),>(s,g)))";
            Assert.AreEqual(expected_proposition, proposition.getPropositionASCIIFormat());
        }
        [TestMethod]
        public void doesItCalculatePropsCorrectlyTest()
        {
            Proposition proposition = new Proposition("|(=(>(1,1),>(1,1)),=(>(1,1),>(1,1)))");
            bool expected_result = true;
            Assert.AreEqual(expected_result, proposition.calculate());
        }
    }
}
