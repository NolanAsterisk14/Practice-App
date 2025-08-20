using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PracticeApp2;

namespace UnitTestProjectPractice2
{
    [TestClass]
    public class MedianUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<float> inputNums = new List<float> { 2, 4, 6, 8 };             //Arrange

            float median = Program.Median(inputNums);                           //Act

            Assert.AreEqual(5, median);                                         //Assert
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<float> inputNums = new List<float> { 2, 4, 6, 8, 10 };         //Arrange

            float median = Program.Median(inputNums);                           //Act

            Assert.AreEqual(6, median);                                         //Assert
        }
    }
}
