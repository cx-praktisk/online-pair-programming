using System.Collections.Generic;

namespace WordChains
{
    public static class FindWordChains
    {
        public static int DistanceTo(this string word, string anotherWord)
        {
            return 1;
        }

        public static IEnumerable<string> FindWordChain(this IEnumerable<string> dictionary, string fromWord, string toWord, int withDistance = 1)
        {
            return new List<string>();
        }

        public static string ToDisplayString(this IEnumerable<string> wordChain) => string.Join(" -> ", wordChain);
    }
}
