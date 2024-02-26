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
        [DataRow("dumb", "TM")]
        [DataRow("thumb", "TM")]
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
        [DataRow("McHugh","MK")]
        [DataRow("bellocchio", "PLK")]
        [DataRow("accident", "AKST")]
        [DataRow("bertucci", "PRTX")]
        [DataRow("snider", "XNTR")]
        [DataRow("scheider", "SKTR")]
        [DataRow("schooner", "XKNR")]
        [DataRow("schenker", "XKNK")]
        [DataRow("island", "ALNT")]
        [DataRow("SUGAR", "SKR")]
        [DataRow("MACHER", "MKR")]
        [DataRow("mac caffrey", "MKFR")]
        [DataRow("edge", "AJ")]
        [DataRow("edgar", "ATKR")]
        [DataRow("ghislane","JLN")]
        [DataRow("ghiradelli", "JRTL")]
        [DataRow("cough", "K")]
        [DataRow("laugh", "L")]
        [DataRow("gough", "K")]
        [DataRow("rough", "R")]
        [DataRow("tough", "T")]
        [DataRow("McLaughlin", "MKLL")]
        [DataRow("tagliaro", "TLR")]
        [DataRow("gelato", "JLT")]
        [DataRow("germany", "JRMN")]
        [DataRow("merger", "MRKR")]
        [DataRow("VAN HELSING", "FNLS")]
        [DataRow("gymn", "JMN")]
        [DataRow("jose", "HS")]
        [DataRow("san jacinto", "XNHS")]
        [DataRow("Yankelovich", "ANKL")]
        [DataRow("Jankelowicz", "ANKL")]
        [DataRow("bajador", "PHTR")]
        [DataRow("banjo", "PNJ")]
        [DataRow("cabrillo", "KPR")]
        [DataRow("gallegos", "KKS")]
        [DataRow("campbell", "KMPL")]
        [DataRow("raspberry", "RSPR")]
        [DataRow("resnais", "RSS")]
        [DataRow("artois", "ARTS")]
        [DataRow("thomas", "TMS")]
        [DataRow("thames", "TMS")]
        [DataRow("Arnow", "ARNF")]
        [DataRow("Arnoff", "ARNF")]
        [DataRow("filipowicz", "FLPF")]
        [DataRow("breaux", "PR")]
        [DataRow("zhao", "J")]
        [DataRow("zoro", "SR")]
        [DataRow("uovo", "AF")]
        [DataRow("Heimhausen", "HMSN")]
        [DataRow("holz", "HLS")]
        [DataRow("Ã","S")]
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
