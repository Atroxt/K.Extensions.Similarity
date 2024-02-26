using System;

namespace K.Extensions.Similarity.Tests
{
    [TestClass]
    public class LongestCommonSubsequenceExtensionTests
    {
        [TestMethod]
        [DataRow("MÜLLER", "MULLER",  "MLLER", .472)]
        [DataRow("FÜR", "VIER",  "R", 0.083)]
        [DataRow("Test", "Test",  "Test", 1.0)]
        [DataRow("Test", "test",  "est", 0.562)]
        [DataRow("", "Test",  "", 0.0)]
        public void TestLongestCommonSubsequence(string input, string comparedTo, string expectedSubsequence, double expectedCoefficient)
        {
            // Act
            Tuple<string, double> actualResult = input.LongestCommonSubsequence(comparedTo);

            // Assert
            Assert.AreEqual(expectedSubsequence, actualResult.Item1, "LongestCommonSubsequence did not return the expected subsequence.");
            Assert.AreEqual(expectedCoefficient, actualResult.Item2, 0.001, "LongestCommonSubsequence did not return the expected coefficient.");
        }
    }
}
