using System;

namespace K.Extensions.Similarity
{
    /// <summary>
    /// Provides extension methods for calculating the Jaro-Winkler similarity between two strings.
    /// </summary>
    public static class JaroWinklerSimilarityExtension
    {
        /// <summary>
        /// Calculates the Jaro-Winkler similarity between the current string and the provided string.
        /// The Jaro-Winkler similarity is a measure of similarity between two strings and is a variant of the Jaro distance metric.
        /// It is a type of string edit distance and is used in the field of record linkage (duplicate detection).
        /// The higher the Jaro-Winkler similarity, the more similar the strings are.
        /// 0 means no similarity, 1 means the strings are equal.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="compareTo">The compareTo string.</param>
        /// <returns>The Jaro-Winkler similarity between the two strings.</returns>
        public static double JaroWinklerSimilarity(this string input, string compareTo)
        {
            int maxLength = Math.Max(input.Length, compareTo.Length);

            // Übereinstimmende Zeichen zählen
            int matchingCharacters = 0;
            int matchingLimit = Math.Min(input.Length, compareTo.Length) / 2;
            bool[] sourceMatched = new bool[input.Length];
            bool[] targetMatched = new bool[compareTo.Length];

            for (int i = 0; i < input.Length; i++)
            {
                int start = Math.Max(0, i - matchingLimit);
                int end = Math.Min(i + matchingLimit + 1, compareTo.Length);

                for (int j = start; j < end; j++)
                {
                    if (!targetMatched[j] && input[i] == compareTo[j])
                    {
                        sourceMatched[i] = true;
                        targetMatched[j] = true;
                        matchingCharacters++;
                        break;
                    }
                }
            }

            if (matchingCharacters == 0)
                return 0.0;

            // Übereinstimmende Zeichen in den richtigen Positionen zählen
            int transpositions = 0;
            int k = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (sourceMatched[i])
                {
                    while (!targetMatched[k])
                        k++;

                    if (input[i] != compareTo[k])
                        transpositions++;

                    k++;
                }
            }

            // Jaro-Winkler-Similarity-Koeffizient berechnen
            double jaroSimilarity = ((double)matchingCharacters / input.Length +
                                      (double)matchingCharacters / compareTo.Length +
                                      ((double)matchingCharacters - (double)transpositions / 2) / matchingCharacters) / 3;

            // Längenunterschiede berücksichtigen
            double prefixLength = 0;
            for (int i = 0; i < Math.Min(4, Math.Min(input.Length, compareTo.Length)); i++)
            {
                if (input[i] == compareTo[i])
                    prefixLength++;
                else
                    break;
            }

            // Skalierungsfaktor und Jaro-Winkler-Ähnlichkeit anwenden
            double scalingFactor = 0.1;
            double jaroWinklerSimilarity = jaroSimilarity + (prefixLength * scalingFactor * (1 - jaroSimilarity));

            return jaroWinklerSimilarity;
        }
    }
}
