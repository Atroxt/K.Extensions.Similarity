namespace K.Extensions.Similarity.Tests
{
    [TestClass]
    public class DiceCoefficientExtensionTests
    {
        [TestMethod]
        [DataRow("M�LLER", "MULLER", 0.8)]
        [DataRow("F�R", "VIER", 0.285)]
        [DataRow("Test", "Test", 1.0)]
        [DataRow("Test", "test", .857)]
        [DataRow("", "Test", 0.0)]
        public void TestDiceCoefficient(string input, string comparedTo, double expectedCoefficient)
        {
            // Act
            double actualCoefficient = input.DiceCoefficient(comparedTo);

            // Assert
            Assert.AreEqual(expectedCoefficient, actualCoefficient, 0.001, "DiceCoefficient did not return the expected value.");
        }
    }
}
