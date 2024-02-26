using System.Linq;

namespace K.Extensions.Similarity
{
    public static class DiceCoefficientExtension
    {

        /// <summary>
        /// Calculates the Dice coefficient between two strings.
        /// The Dice coefficient is a measure of similarity between two strings.
        /// 0 means no similarity, 1 means the strings are equal.
        /// </summary>
        /// <param name="input">The first string.</param>
        /// <param name="comparedTo">The second string.</param>
        /// <returns>The Dice coefficient between the two strings.</returns>

        public static double DiceCoefficient(this string input, string comparedTo)
        {
            // Convert strings to sets of characters
            var set1 = input.ToHashSet();
            var set2 = comparedTo.ToHashSet();

            // Calculate intersection size
            int intersection = set1.Intersect(set2).Count();

            // Calculate Dice coefficient
            return 2.0 * intersection / (set1.Count + set2.Count);
        }
    }
}
