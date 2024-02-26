using System;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("K.Extensions.String.Tests")]
namespace K.Extensions.Similarity
{
    public static class StringExtension
    {

        /// <summary>
        /// Calculates the similarity between two strings using various algorithms.
        /// </summary>
        /// <param name="input">The first string to compare.</param>
        /// <param name="comparedTo">The second string to compare.</param>
        /// <returns>The average similarity score between the two strings.</returns>
        public static double Similarity(this string input, string comparedTo)
        {
            var levenshtein = input.LevenshteinDistance(comparedTo);
            double levenshteinSimilarity = 1 - (double)levenshtein / Math.Max(input.Length, comparedTo.Length);
            double longestCommonSubsequenceSimilarity = input.LongestCommonSubsequence(comparedTo).Item2;
            double diceCoefficientSimilarity = input.DiceCoefficient(comparedTo);

            #region Double Metaphone
            string strAMp = input.ToDoubleMetaphone();
            string strBMp = comparedTo.ToDoubleMetaphone();
            int matchingChars = CountMatchingChars(strAMp, strBMp);
            int maxLength = Math.Max(strAMp.Length, strBMp.Length);
            double doubleMetaphoneSimilarity = (double)matchingChars / maxLength;
            #endregion

            // Einen Durchschnittswert der Ähnlichkeiten berechnen
            double averageSimilarity = (levenshteinSimilarity + longestCommonSubsequenceSimilarity +
                                        diceCoefficientSimilarity + doubleMetaphoneSimilarity) / 4;

            return averageSimilarity;
        }
        /// <summary>
        /// Counts the number of matching characters in two strings.
        /// </summary>
        /// <param name="str1">The first string to compare.</param>
        /// <param name="str2">The second string to compare.</param>
        /// <returns>The number of matching characters in the two strings.</returns>
        private static int CountMatchingChars(string str1, string str2)
        {
            int matchingChars = 0;
            int minLength = Math.Min(str1.Length, str2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (str1[i] == str2[i])
                {
                    matchingChars++;
                }
            }

            return matchingChars;
        }
        /// <summary>
        /// Determines if two strings are similar based on a required probability score.
        /// </summary>
        /// <param name="input">The first string to compare.</param>
        /// <param name="comparedTo">The second string to compare.</param>
        /// <param name="requiredProbabilityScore">The required probability score for the strings to be considered similar. Default is 0.48.</param>
        /// <returns>True if the composite coefficient of similarity between the two strings is greater than the required probability score, otherwise false.</returns>
        public static bool IsSimilar(this string input, string comparedTo, double requiredProbabilityScore = 0.48)
        {
            return input.Similarity(comparedTo) > requiredProbabilityScore;
        }

    }
}
