using System;

namespace K.Extensions.Similarity
{
    public static class LongestCommonSubsequenceExtension
    {
        /// <summary>
        /// Finds the Longest Common Subsequence (LCS) between two strings.
        /// </summary>
        /// <remarks>
        /// A good match coefficient is greater than 0.33.
        /// </remarks>
        /// <param name="input">The input string.</param>
        /// <param name="comparedTo">The string to compare against.</param>
        /// <returns>Returns a Tuple containing the longest common subsequence and the match coefficient.</returns>
        public static Tuple<string, double> LongestCommonSubsequence(this string input, string comparedTo)
        {
            // Check for null or empty input strings
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(comparedTo))
                return Tuple.Create(string.Empty, 0.0d);

            int inputLen = input.Length;
            int comparedToLen = comparedTo.Length;

            // Arrays to store lengths, directions, and weights
            int[,] lcs = new int[inputLen + 1, comparedToLen + 1];
            LcsDirection[,] tracks = new LcsDirection[inputLen + 1, comparedToLen + 1];
            int[,] w = new int[inputLen + 1, comparedToLen + 1];

            // Initialize first row and column
            for (int i = 0; i <= inputLen; ++i)
            {
                lcs[i, 0] = 0;
                tracks[i, 0] = LcsDirection.North;
            }
            for (int j = 0; j <= comparedToLen; ++j)
            {
                lcs[0, j] = 0;
                tracks[0, j] = LcsDirection.West;
            }

            // Dynamic programming approach to find LCS
            for (int i = 1; i <= inputLen; ++i)
            {
                for (int j = 1; j <= comparedToLen; ++j)
                {
                    if (input[i - 1].Equals(comparedTo[j - 1]))
                    {
                        int k = w[i - 1, j - 1];
                        lcs[i, j] = lcs[i - 1, j - 1] + Square(k + 1) - Square(k);
                        tracks[i, j] = LcsDirection.NorthWest;
                        w[i, j] = k + 1;
                    }
                    else
                    {
                        lcs[i, j] = lcs[i - 1, j - 1];
                        tracks[i, j] = LcsDirection.None;
                    }

                    if (lcs[i - 1, j] >= lcs[i, j])
                    {
                        lcs[i, j] = lcs[i - 1, j];
                        tracks[i, j] = LcsDirection.North;
                        w[i, j] = 0;
                    }

                    if (lcs[i, j - 1] >= lcs[i, j])
                    {
                        lcs[i, j] = lcs[i, j - 1];
                        tracks[i, j] = LcsDirection.West;
                        w[i, j] = 0;
                    }
                }
            }

            // Trace back to construct the subsequence
            string subsequence = "";
            double p = lcs[inputLen, comparedToLen];
            int x = inputLen, y = comparedToLen;

            while (x > 0 || y > 0)
            {
                if (tracks[x, y] == LcsDirection.NorthWest)
                {
                    x--;
                    y--;
                    subsequence = input[x] + subsequence;
                }
                else if (tracks[x, y] == LcsDirection.North)
                    x--;
                else if (tracks[x, y] == LcsDirection.West)
                    y--;
            }

            // Calculate match coefficient
            double coefficient = p / (inputLen * comparedToLen);

            return Tuple.Create(subsequence, coefficient);
        }

        private static int Square(int p)
        {
            return p * p;
        }
    }
    internal enum LcsDirection
    {
        None,
        North,
        West,
        NorthWest
    }
}
