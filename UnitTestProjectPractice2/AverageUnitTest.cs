using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PracticeApp2;

namespace UnitTestProjectPractice2
{
    [TestClass]
    public class AverageUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<float> inputFloats = new List<float> {10, 15, 20, 25};             //Arrange

            float average = Program.Average(inputFloats);                           //Act

            Assert.AreEqual(17.5, average);                                         //Assert
        }
    }
}
