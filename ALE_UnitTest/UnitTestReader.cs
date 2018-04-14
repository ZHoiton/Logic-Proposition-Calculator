using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ALE1_test;
using System.Text.RegularExpressions;

namespace ALE_UnitTest
{
    [TestClass]
    public class UnitTestReader
    {
        string test_string = "asd, adwda, ad,wades!@#41 123 sd";
        string expected_string = "asd,adwda,ad,wades!@#41123sd";
        string test_proposition = "=(>(a  ,B)  ,a)";
        string expected_proposition = "=(>(a,B),a)";

        [TestMethod]
        public void readerConstructorTest()
        {
            Reader reader = new Reader(test_string);
            string result_string = reader.ProcessedInput;
            Assert.AreEqual(expected_string, result_string);
        }
        [TestMethod]
        public void readerConstructorSecondTest()
        {
            Reader reader = new Reader(test_string+test_string);
            string result_string = reader.ProcessedInput;
            Assert.AreEqual(expected_string+expected_string, result_string);
        }
        [TestMethod]
        public void readerConstructorExtraTest()
        {
            Reader reader = new Reader("~(=(>(=(>(a,B)   ,|(  |(>(A,b),  ~(B))   ,a )),a),>(=(>(a,B)   ,|(  ~(b   ),a )),a)))");
            string result_string = reader.ProcessedInput;
            Assert.AreEqual("~(=(>(=(>(a,B),|(|(>(A,b),~(B)),a)),a),>(=(>(a,B),|(~(b),a)),a)))", result_string);
        }
        [TestMethod]
        public void cleanStringTest()
        {
            Reader reader = new Reader(test_string);
            string[] temp_array = Regex.Split(test_proposition, string.Empty);
            string[] new_temp_array = reader.cleanString(temp_array, 0);
            string new_string = "";
            foreach (string c in new_temp_array)
            {
                new_string += c;
            }
            Assert.AreEqual(expected_proposition, new_string);
        }
        [TestMethod]
        public void replaceUniquePredicatesTest()
        {
            Reader reader = new Reader(test_proposition);
            string[] prediccate_values = {"1","0"};
            string method_result = reader.replaceUniquePredicates(reader.ProcessedInput, prediccate_values);
            Console.WriteLine("asd");
            Console.WriteLine(method_result);
            Assert.AreEqual("=(>(1,0),1)", method_result);
        }
        [TestMethod]
        public void generateTruthTableTest()
        {
            Reader reader = new Reader(test_proposition);
            string[,] result_table = reader.generateTruthTableWithUniqueChars();
            string[,] expected_result = {{"a","B"},{"1","1"},{"1","0"},{"0","1"},{"0","0"}};
            CollectionAssert.AreEqual(expected_result, result_table);

        }
        [TestMethod]
        public void getNumberOfUniquePredicatesTest()
        {
            Reader reader = new Reader(test_string);
            int number_of_predicates = reader.getNumberOfUniquePredicates(reader.ProcessedInput);
            int expected_number = 5;
            Assert.AreEqual(expected_number, number_of_predicates);
        }
        [TestMethod]
        public void getUniquePredicatesTest()
        {
            Reader reader = new Reader(test_string);
            string[] predicates = reader.getUniquePredicates(reader.ProcessedInput);
            string[] expected_predicates = { "a", "s", "d", "w", "e" };
            CollectionAssert.AreEqual(expected_predicates, predicates);
        }
        [TestMethod]
        public void checkForCharTest()
        {
            Reader reader = new Reader(test_string);
            List<char> list_of_chars = new List<char>();
            list_of_chars.Add('a');
            list_of_chars.Add('B');
            list_of_chars.Add('b');
            bool is_char_present = false;
            bool result = reader.checkForChar(list_of_chars, 'a');
            Assert.AreEqual(is_char_present, result);
        }
        [TestMethod]
        public void checkForCharSecondTest()
        {
            Reader reader = new Reader(test_string);
            List<char> list_of_chars = new List<char>();
            list_of_chars.Add('M');
            list_of_chars.Add('B');
            list_of_chars.Add('b');
            list_of_chars.Add('q');
            list_of_chars.Add('Q');
            list_of_chars.Add('E');
            list_of_chars.Add('e');
            bool is_char_present = true;
            bool result = reader.checkForChar(list_of_chars, 'a');
            Assert.AreEqual(is_char_present, result);
        }
    }
}
