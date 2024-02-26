namespace K.Extensions.Similarity.Tests
{
    [TestClass]
    public class LevenshteinDistanceExtensionTests
    {
        [TestMethod]
        [DataRow("Häuser", "Hauser", 1)]
        [DataRow("Levenshtein", "Levenshtain", 1)]
        [DataRow("Haus", "Maus", 1)]
        [DataRow("Book", "Back", 2)]
        [DataRow("abcdef", "azced", 3)]
        [DataRow("", "test", 4)]
        [DataRow("test", "", 4)]
        [DataRow("kitten", "sitting", 3)]
        [DataRow("Saturday", "Sunday", 3)]
        [DataRow("k", "s", 1)]
        [DataRow("Müller", "Mueller", 2)]
        [DataRow("Übung", "Uebung", 2)] 
        [DataRow("Straße", "Strasse", 2)]
        [DataRow("über", "ueber", 2)]
        [DataRow("über", "uber", 1)]
        public void LevenshteinDistance_ReturnsCorrectDistance(string input, string comparedTo, int distance)
        {
            var result = input.LevenshteinDistance(comparedTo);
            Assert.AreEqual(distance, result);
        }
    }
}