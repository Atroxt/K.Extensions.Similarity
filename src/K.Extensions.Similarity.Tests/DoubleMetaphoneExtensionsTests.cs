namespace K.Extensions.Similarity.Tests
{
    [TestClass]
    public class DoubleMetaphoneExtensionsTests
    {
        [TestMethod]
        [DataRow("MÜLLER", "MLR")]
        [DataRow("FÜR", "FR")]
        [DataRow("Test", "TST")]
        [DataRow("test", "TST")]
        [DataRow("china", "KN")]
        [DataRow("", "")]
        public void TestToDoubleMetaphone(string input, string expectedMetaphone)
        {
            // Act
            string actualMetaphone = input.ToDoubleMetaphone();

            // Assert
            Assert.AreEqual(expectedMetaphone, actualMetaphone, "ToDoubleMetaphone did not return the expected value.");
        }
    }
}
