using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckPointModel.Utilities;
using System.Collections.Generic;

namespace CheckPointTestProject
{
    [TestClass]
    public class ValidateIntegerInputTest
    {
        [TestMethod]
        public void IsIntegerValidTest1()
        {
            int myint = 200;
            bool actualIntegerResult = ValidateIntergerInput.IsIntergerValid(myint);

            Assert.AreEqual(true, actualIntegerResult, null, "integer test failed");
        }

        [TestMethod]
        public void IsIntegerValidTest2()
        {
            int myint = -5;
            bool actualIntegerResult = ValidateIntergerInput.IsIntergerValid(myint);

            Assert.AreEqual(false, actualIntegerResult, null, "integer test failed");
        }

        [TestMethod]
        public void AreIntegersValidTest1()
        {
            List<int> myIntList = new List<int>();

            myIntList.Add(1);
            myIntList.Add(2);
            myIntList.Add(3);

            bool actualIntegersResult = ValidateIntergerInput.AreIntegersValid(myIntList);

            Assert.AreEqual(true, actualIntegersResult, null, "the integer test failed");
        }

        [TestMethod]
        public void AreIntegersValidTest2()
        {
            List<int> myIntList = new List<int>();

            myIntList.Add(-1);
            myIntList.Add(-2);
            myIntList.Add(-3);

            bool actualIntegersResult = ValidateIntergerInput.AreIntegersValid(myIntList);

            Assert.AreEqual(false, actualIntegersResult, null, "the integer test failed");
        }
    }
}
