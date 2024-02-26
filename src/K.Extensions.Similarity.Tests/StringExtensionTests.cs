using System;
using System.Text;

namespace K.Extensions.Similarity.Tests
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        [DataRow("MÜLLER", "MULLER",.776)]
        [DataRow("FÜR", "VIER",.404)]
        [DataRow("FIER", "VIER", .765)]
        [DataRow("FÜR", "FUR", .638)]
        [DataRow("Test", "Test",1)]
        [DataRow("Test", "test",.792)]
        [DataRow("", "Test",0)]
        [DataRow("Hans", "Wurst",.18)]
        public void Can_CalculateSimilarity(string input, string comparedTo,double expected)
        {
            var result = input.Similarity(comparedTo);
            Console.WriteLine(result);
            Assert.AreEqual(expected, result, 0.001);
        }
        [TestMethod]
        [DataRow("MÜLLER", "MULLER", .776)]
        [DataRow("FÜR", "VIER", .404)]
        [DataRow("FIER", "VIER", .765)]
        [DataRow("FÜR", "FUR", .638)]
        [DataRow("Test", "Test", 1)]
        [DataRow("Test", "test", 1)]
        [DataRow("", "Test", 0)]
        [DataRow("Hans", "Wurst", .18)]
        public void Can_CalculateSimilarity_ToUpper(string input, string comparedTo, double expected)
        {
            input = input.Normalize(NormalizationForm.FormC);
            comparedTo = comparedTo.Normalize(NormalizationForm.FormC);
            var result = input.ToUpper().Similarity(comparedTo.ToUpper());
            Console.WriteLine(result);
            Assert.AreEqual(expected, result, 0.001);
        }


        [TestMethod]
        [DataRow("MÜLLER", "MULLER", 0.48, true)]
        [DataRow("FÜR", "VIER", 0.48, false)]
        [DataRow("FIER", "VIER", 0.48, true)]
        [DataRow("FÜR", "FUR", 0.48, true)]
        [DataRow("Test", "Test", 0.48, true)]
        [DataRow("Test", "test", 0.48, true)]
        [DataRow("", "Test", 0.48, false)]
        [DataRow("Hans", "Wurst", 0.48, false)]
        public void TestIsSimilar(string input, string comparedTo, double requiredProbabilityScore, bool expectedResult)
        {
            // Act
            bool actualResult = input.ToLower().IsSimilar(comparedTo.ToLower(), requiredProbabilityScore);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, "IsSimilar did not return the expected result.");
        }
    }
}
