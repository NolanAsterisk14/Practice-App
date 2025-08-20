using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PracticeApp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestAverage
    {
        [TestMethod]
        public void TestMethodAverage()
        {
            List<float> inputVals = new List<float>();              //Arrange
            inputVals.Add(20);
            inputVals.Add(30);
            inputVals.Add(40);
            inputVals.Add(50);

            float average = Program.Average(inputVals);             //Act

            Assert.AreEqual(35f, average);                          //Assert
        }
    }
}
