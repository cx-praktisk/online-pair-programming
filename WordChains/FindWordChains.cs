using System;
using System.Collections.Generic;
using System.Linq;

namespace WordChains
{
    public static class FindWordChains
    {
        public static int DistanceTo(this string word, string anotherWord)
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

        public static IEnumerable<string> FindWordsWithDistanceFrom(this IEnumerable<string> dictionary, string anotherWord, int distance = 1) =>
            dictionary
                .Where(word => word.Length == anotherWord.Length)
                .Where(word => word.DistanceTo(anotherWord) == distance);

        public static IEnumerable<string> FindWordChain(this IEnumerable<string> dictionary, string fromWord, string toWord, int withDistance = 1, string[] andAccumulator = null)
        {
            andAccumulator ??= new string[] { fromWord };
            if (fromWord.Equals(toWord))
            {
                return andAccumulator;
            }

            return dictionary
                .FindWordsWithDistanceFrom(anotherWord: fromWord, distance: withDistance)
                .Select(nextWord => dictionary
                    .Where(word => !word.Equals(fromWord))
                    .FindWordChain(
                        fromWord: nextWord,
                        toWord: toWord,
                        withDistance: withDistance,
                        andAccumulator: andAccumulator.Append(nextWord)))
                .FirstOrDefault(wordChain => wordChain != null);
        }

        public static string ToDisplayString(this IEnumerable<string> wordChain) => string.Join(" -> ", wordChain);

        private static string[] Append(this string[] source, string element)
        {
            var target = new string[source.Length + 1];
            Array.Copy(source, target, source.Length);
            target[source.Length] = element;
            return target;
        }
    }
}
