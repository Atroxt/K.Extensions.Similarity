using System;

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
        [DataRow("KNACK", "NK")]
        [DataRow("Xavier", "SFR")]
        [DataRow("Achen", "AKN")]
        [DataRow("dump", "TMP")]
        [DataRow("SURE", "SR")]
        [DataRow("CHARACTER", "KRKT")]
        [DataRow("CAESAR", "SSR")]
        [DataRow("CHIANTI", "KNT")]
        [DataRow("MICHAEL", "MXL")]
        [DataRow("CHORUS", "KRS")]
        [DataRow("McHugh", "MK")]
        [DataRow("wechsler", "FKSL")]
        [DataRow("orchestra", "ARKS")]
        [DataRow("czerny", "XRN")]
        [DataRow("focaccia", "FXX")]
        [DataRow("McClellan", "MKLL")]
        [DataRow("bellocchio", "PLK")]
        [DataRow("accident", "AKST")]
        [DataRow("bertucci", "PRTX")]
        [DataRow("snider", "XNTR")]
        [DataRow("scheider", "SKTR")]
        [DataRow("schooner", "XKNR")]
        [DataRow("schenker", "XKNK")]
        [DataRow("island", "ALNT")]
        [DataRow("SUGAR", "SKR")]
        [DataRow("", "")]
        public void TestToDoubleMetaphone(string input, string expectedMetaphone)
        {
            // Act
            string actualMetaphone = input.ToDoubleMetaphone();

            // Assert
            Assert.AreEqual(expectedMetaphone, actualMetaphone, "ToDoubleMetaphone did not return the expected value.");
        }
        [TestMethod]
        [DataRow('A', true)]
        [DataRow('B', false)]
        public void TestIsVowel(char input, bool isVowel)
        {
            // Act
            bool isVowelChar = input.IsVowel();
            // Assert
            Assert.AreEqual(isVowel, isVowelChar, "IsVowel did not return the expected value.");
        }

    }
}
