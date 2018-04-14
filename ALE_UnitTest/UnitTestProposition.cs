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
        public void doesItConsumePropsCorrectlySecondTest()
        {
            Proposition proposition = new Proposition(">(d,B)");
            string expected_proposition = ">(d,B)";
            Assert.AreEqual(expected_proposition, proposition.getPropositionASCIIFormat());
        }
        [TestMethod]
        public void doesItConsumePropsCorrectlyWithNOTTest()
        {
            Proposition proposition = new Proposition("|(~(>(a,b)),c)");
            string expected_proposition = "|(~(>(a,b)),c)";
            Assert.AreEqual(expected_proposition, proposition.getPropositionASCIIFormat());
        }
        [TestMethod]
        public void doesItConsumePropsCorrectlyWithNOTSecondTest()
        {
            Proposition proposition = new Proposition("~(|(~(>(a,b)),=(c,f)))");
            string expected_proposition = "~(|(~(>(a,b)),=(c,f)))";
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
