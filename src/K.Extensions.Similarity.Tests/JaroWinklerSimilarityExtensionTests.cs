namespace K.Extensions.Similarity.Tests
{
    [TestClass]
    public class JaroWinklerSimilarityExtensionTests
    {
        [TestMethod]
        [DataRow("MARTHA", "MARHTA", 0.961)]
        [DataRow("DWAYNE", "DUANE", 0.84)]
        [DataRow("JONES", "JOHNSON", 0.832)]
        [DataRow("ABCVWXYZ", "CABVWXYZ", 0.9375)]
        [DataRow("MÜLLER", "MULLER", 0.9)]
        [DataRow("MÜLLER", "MILLER", 0.9)]
        [DataRow("FÜR", "VIER", .527)]
        [DataRow("", "Test", 0)]
        [DataRow("Test", "Test", 1)]
        [DataRow("Test", "test", .833)]
        public void TestJaroWinklerSimilarity(string source, string target, double expectedSimilarity)
        {
            // Act
            double actualSimilarity = source.JaroWinklerSimilarity(target);

            // Assert
            Assert.AreEqual(expectedSimilarity, actualSimilarity, 0.001, "JaroWinklerSimilarity did not return the expected value.");
        }
    }
}
