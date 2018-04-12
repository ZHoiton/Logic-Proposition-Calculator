using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE1_test;
using System.Collections.Generic;

namespace ALE_UnitTest
{
    [TestClass]
    public class UnitTestSimplifier
    {
        [TestMethod]
        public void ifElementsAreTheSameTrueTest()
        {
            Simplifyer simplifier = new Simplifyer();
            string[] element = { "1", "0", "*", "0", "1", "*", "1", "*", "1", "1", "1", "0" };
            bool result = simplifier.checkIfElementsAreTheSame(element, element);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void ifElementsAreTheSameFalseTest()
        {
            Simplifyer simplifier = new Simplifyer();
            string[] first_element = { "1", "0", "*", "0", "1", "*", "1", "*", "1", "1", "1", "0" };
            string[] second_element = { "1", "*", "*", "0", "1", "*", "1", "*", "1", "1", "1", "0" };
            bool result = simplifier.checkIfElementsAreTheSame(first_element, second_element);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void DistinctElementsTest()
        {
            Simplifyer simplifier = new Simplifyer();

            string[] asd_string = { "asd", "asd", "asd" };
            string[] qwe_string = { "qwe", "qwe", "qwe" };
            string[] sda_string = { "sda", "sda", "sda" };
            string[] number_string = { "123", "123", "123" };

            List<string[]> list = new List<string[]>();

            list.Add(asd_string);
            list.Add(asd_string);
            list.Add(sda_string);
            list.Add(sda_string);
            list.Add(number_string);
            list.Add(asd_string);
            list.Add(qwe_string);
            list.Add(asd_string);
            list.Add(sda_string);
            list.Add(asd_string);
            list.Add(qwe_string);
            list.Add(number_string);

            List<string[]> explected_result_list = new List<string[]>();
            explected_result_list.Add(asd_string);
            explected_result_list.Add(sda_string);
            explected_result_list.Add(number_string);
            explected_result_list.Add(qwe_string);

            List<string[]> result = simplifier.getDistinctElements(list);
            CollectionAssert.AreEqual(explected_result_list, result);
        }
        [TestMethod]
        public void canItSimplifyMoreTrueTest()
        {
            Simplifyer simplifier = new Simplifyer();
            string[] first_element = { "1", "0", "*", "1" };
            string[] second_element = { "1", "1", "*", "1" };
            bool result = simplifier.checkIsPossibleToSimplify(first_element, second_element);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void canItSimplifyMoreFalseTest()
        {
            Simplifyer simplifier = new Simplifyer();
            string[] first_element = { "1", "0", "*", "*" };
            string[] second_element = { "0", "1", "*", "1" };
            bool result = simplifier.checkIsPossibleToSimplify(first_element, second_element);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void continueToSimplifyMoreTrueTest()
        {
            Simplifyer simplifier = new Simplifyer();
            string[] first_element = { "1", "0", "*", "1" };
            bool result = simplifier.continueToSimplify(first_element);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void continueToSimplifyMoreFalseTest()
        {
            Simplifyer simplifier = new Simplifyer();
            string[] first_element = { "1", "*", "*", "1" };
            bool result = simplifier.continueToSimplify(first_element);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void removeInvalidItemsTest()
        {
            Simplifyer simplifier = new Simplifyer();
            string[] prop_string_1 = { "1", "*", "*", "1" };
            string[] prop_string_2 = { "*", "0", "*", "1" };
            string[] prop_string_3 = { "*", "*", "0", "1" };

            string[] prop_string_4 = { "1", "1", "0", "0" };

            List<string[]> simplified_list = new List<string[]>();

            simplified_list.Add(prop_string_1);
            simplified_list.Add(prop_string_2);
            simplified_list.Add(prop_string_3);

            List<string[]> non_simplified = new List<string[]>();
            non_simplified.Add(prop_string_4);

            List<string[]> expected_result = new List<string[]>();
            expected_result.Add(prop_string_2);

            List<string[]> result = simplifier.removeInvalidItems(simplified_list, non_simplified);
            CollectionAssert.AreEqual(expected_result, result);
        }
        [TestMethod]
        public void arePropositionsValidTrueTest()
        {
            Simplifyer simplifier = new Simplifyer();

            string[,] table = { { "a", "B", "c", "test_prop" },
                                { "1", "*", "*", "1" }, 
                                { "*", "*", "0", "1" }, 
                                { "1", "1", "0", "0" } };
            bool result = simplifier.checkIfPropositionsAreValid(table);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void arePropositionsValidFalseTest()
        {
            Simplifyer simplifier = new Simplifyer();

            string[,] table = { { "a", "B", "c", "test_prop" },
                                { "1", "*", "*", "1" }, 
                                { "*", "*", "0", "1" }, 
                                { "*", "0", "*", "1" }, 
                                { "1", "1", "0", "0" } };
            bool result = simplifier.checkIfPropositionsAreValid(table);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void arePropositionsValidFalseSecondTest()
        {
            Simplifyer simplifier = new Simplifyer();

            string[,] table = { { "a", "B", "c", "test_prop" },
                                { "*", "0", "*", "1" }, 
                                { "1", "1", "0", "0" } };
            bool result = simplifier.checkIfPropositionsAreValid(table);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void getSimplifiedTableTest()
        {
            Simplifyer simplifier = new Simplifyer();

            string[,] test_table = { { "a", "B", "c", "=(>(a,B),c)" },
                                    { "1", "1", "1", "1" }, 
                                    { "1", "1", "0", "0" },
                                    { "1", "0", "1", "0" }, 
                                    { "1", "0", "0", "1" },
                                    { "0", "1", "1", "1" }, 
                                    { "0", "1", "0", "0" },
                                    { "0", "0", "1", "1" }, 
                                    { "0", "0", "0", "0" }};
            string[,] simplified_table = simplifier.getSimplifyedTruthTable(test_table);
            string[,] expected_result ={ { "a", "B", "c", "=(>(a,B),c)" },
                                        { "1", "1", "0", "0" },
                                        { "1", "0", "1", "0" },
                                        { "0", "1", "0", "0" }, 
                                        { "0", "0", "0", "0" },
                                        { "*", "1", "1", "1" }, 
                                        { "0", "*", "1", "1" }};
            CollectionAssert.AreEqual(expected_result, simplified_table);
        }
    }
}
