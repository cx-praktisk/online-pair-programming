using System;
using System.Collections.Generic;
using System.Linq;

namespace WordChains
{
    public static class Chainmail
    {
        public static int Distance(this string word, string anotherWord)
        {
            if (word.Length != anotherWord.Length)
            {
                throw new ArgumentException("Words must have same length.");
            }

            var distance = 0;
            for (var i = 0; i < word.Length; i++)
            {
                if (word[i] != anotherWord[i])
                {
                    distance++;
                }
            }

            return distance;
        }

        public static IEnumerable<string> WithDistanceFrom(this IEnumerable<string> dictionary, string anotherWord, int distance = 1) =>
            dictionary
                .Where(word => word.Length == anotherWord.Length)
                .Where(word => word.Distance(anotherWord) == distance);

        public static string ChainWithDistanceTo(this IEnumerable<string> dictionary, string word, string anotherWord, int distance = 1)
        {
            if (word.Equals(anotherWord))
            {
                return anotherWord;
            }

            var words = dictionary.WithDistanceFrom(word, distance);
            if (!words.Any())
            {
                return null;
            }

            var wordRemoved = dictionary.Where(w => !w.Equals(word));
            var match = words
                .Select(w => wordRemoved.ChainWithDistanceTo(w, anotherWord, distance))
                .Where(w => w != null)
                .FirstOrDefault();

            if (match == null)
            {
                return null;
            }

            return $"{word} -> {match}";
        }

        public static string ChainTo(this IEnumerable<string> dictionary, string word, string anotherWord) =>
            dictionary
                .Where(w => w.Length == word.Length)
                .ChainWithDistanceTo(word, anotherWord, 1);
    }
}
