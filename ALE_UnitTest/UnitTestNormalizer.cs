using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE1_test;

namespace ALE_UnitTest
{
    [TestClass]
    public class UnitTestNormalizer
    {
        string[,] truth_table = { { "a", "B", ">(a,B)" }, { "1", "1", "1" }, { "1", "0", "0" }, { "0", "1", "1" }, { "0", "0", "1" } };
        string[,] simplified_table = { { "a", "B", ">(a,B)" }, { "1", "0", "0" }, { "*", "1", "1" }, { "0", "*", "1" } };
            
        [TestMethod]
        public void TestDNF()
        {
            Normalizator normalizor = new Normalizator(truth_table,simplified_table);
            string expected_result = "|(|(&(a,B),&(~(a),B)),&(~(a),~(B)))";
            string resut = normalizor.getDNFFromTruthTable();
            Assert.AreEqual(expected_result, resut);
        }
        [TestMethod]
        public void TestSimplifiedDNF()
        {
            Normalizator normalizor = new Normalizator(truth_table, simplified_table);
            string expected_result = "|(B,~(a))";
            string resut = normalizor.getDNFFromSimplifiedTruthTable();
            Assert.AreEqual(expected_result, resut);
        }
    }
}
