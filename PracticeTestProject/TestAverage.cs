using PracticeApp;

namespace PracticeTestProject
{
    [TestClass]
    public sealed class TestAverage
    {
        [TestMethod]
        public void TestMethodAverage()
        {
            List<float> inputVals = [20, 30, 40, 50];               //Arrange

            float average = Program.Average(inputVals);             //Act

            Assert.AreEqual(35f, average);                          //Assert
        }
    }
}
