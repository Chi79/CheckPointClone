using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckPointModel.Utilities;
using System.Collections.Generic;


namespace CheckPointTestProject
{
    [TestClass]
    public class ValidateStringInputTest
    {
        [TestMethod]
        public void TestIsStringValid1()
        {
            string testString = "myteststring";
            bool actualStringResult = ValidateStringInput.IsStringValid(testString);

            Assert.AreEqual(true, actualStringResult, null, "the string test failed");
        }

        [TestMethod]
        public void TestIsStringValid2()
        {
            string testString = "";
            bool actualStringResult = ValidateStringInput.IsStringValid(testString);

            Assert.AreEqual(false, actualStringResult, null, "the string test failed");
        }

        [TestMethod]
        public void TestAreStringsValid1()
        {
            List<string> myTestStrings = new List<string>();
            myTestStrings.Add("string1");
            myTestStrings.Add("string2");
            myTestStrings.Add("string3");

            bool actualStringsResult = ValidateStringInput.AreStringsValid(myTestStrings);

            Assert.AreEqual(true, actualStringsResult, null, "the strings test failed");
        }

        [TestMethod]
        public void TestAreStringsValid2()
        {
            List<string> myTestStrings = new List<string>();
            myTestStrings.Add("");
            myTestStrings.Add("");
            myTestStrings.Add("");

            bool actualStringsResult = ValidateStringInput.AreStringsValid(myTestStrings);

            Assert.AreEqual(false, actualStringsResult, null, "the strings test failed");
        }

    }
}
