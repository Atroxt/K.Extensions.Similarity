using System;
using System.Text;

namespace K.Extensions.Similarity
{
    public static partial class LevenshteinDistanceExtension
    {
        /// <summary>
        /// Calculates the Levenshtein distance between the current string and the provided string.
        /// A value of 0 strings are Equal
        /// 1 or 2 is okay, 3 is iffy and greater than 4 is a poor match
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="comparedTo">The string to compare to.</param>
        /// <returns>The Levenshtein distance between the two strings.</returns>
        public static int LevenshteinDistance(this string input, string comparedTo)
        {
            input = NormalizeString(input);
            comparedTo = NormalizeString(comparedTo);
            int[,] matrix = new int[input.Length + 1, comparedTo.Length + 1];

            // Initialize
            for (int i = 0; i <= matrix.GetUpperBound(0); i++) matrix[i, 0] = i;
            for (int i = 0; i <= matrix.GetUpperBound(1); i++) matrix[0, i] = i;

            // Analyze
            for (int i = 1; i <= matrix.GetUpperBound(0); i++)
            {
                var si = input[i - 1];
                for (int j = 1; j <= matrix.GetUpperBound(1); j++)
                {
                    var tj = comparedTo[j - 1];
                    int cost = (si == tj) ? 0 : 1;

                    var above = matrix[i - 1, j];
                    var left = matrix[i, j - 1];
                    var diag = matrix[i - 1, j - 1];
                    var cell = FindMinimum(above + 1, left + 1, diag + cost);

                    // Transposition
                    if (i > 1 && j > 1 && si != tj && input[i - 2] == tj && comparedTo[j - 2] == si)
                    {
                        var trans = matrix[i - 2, j - 2] + 1;
                        if (cell > trans) cell = trans;
                    }

                    matrix[i, j] = cell;
                }
            }
            return matrix[matrix.GetUpperBound(0), matrix.GetUpperBound(1)];
        }
        static int FindMinimum(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
        static string NormalizeString(string input)
        {
            return input.Normalize(NormalizationForm.FormC);
        }
    }
}
