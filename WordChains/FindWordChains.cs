using System.Collections.Generic;
using System.Linq;

namespace WordChains
{
    public static class FindWordChains
    {
        public static int DistanceTo(this string word, string anotherWord)
        {
            /*
            var wordArray = word.ToCharArray();
            var anotherWordArray = anotherWord.ToCharArray();

            var distance = 0;
            for (int i = 0; i < word.Length; i++)
            {
                distance += wordArray[i] == anotherWordArray[i] ? 0 : 1;
            }

            distance = word
                .Zip(anotherWord, (x, y) => x == y ? 0 : 1)
                .Aggregate(0, (acc, x) => acc + x);
            */

            // Vil bare sjekke hvor samtidig man kan redigere :-)
            // Er bare å kjøre på det. Klassikern er å fikse formatteringsfeil mens den andre koder :-P
            // Så forskjellen her i forhold til vanlig par-programmering er at man kan jobbe asynkront på samme kode.

            // Så jeg kan ta en liten avstikker og legge inn en ny test nå?
            // Definitivt! Do it!

            //                               /
            //                    __       //
            //                    -\= \=\ //
            //                  --=_\=---//=--
            //                -_==/  \/ //\/--
            //                 ==/   /O   O\==--
            //    _ _ _ _     /_/    \  ]  /--
            //   /\ ( (- \    /       ] ] ]==-
            //  (\ _\_\_\-\__/     \  (,_,)--
            // (\_/                 \     \-
            // \/      /       (   ( \  ] /)
            // /      (         \   \_ \./ )
            // (       \         \      )  \
            // (       /\_ _ _ _ /---/ /\_  \
            //  \     / \     / ____/ /   \  \
            //   (   /   )   / /  /__ )   (  )
            //   (  )   / __/ '---`       / /
            //   \  /   \ \             _/ /
            //   ] ]     )_\_         /__\/
            //   /_\     ]___\
            //  (___)

            /*
            if (word == "CAT" && anotherWord == "COG") return 2;
            if (anotherWord == "DOG") return 3;
            */

            return word.Length == anotherWord.Length
                ? word.Zip(anotherWord, (x, y) => x == y ? 0 : 1) // :-)
                    .Aggregate(0, (acc, x) => acc + x)
                : -1;
        }

        public static IEnumerable<string> FindWordChain(this IEnumerable<string> dictionary, string fromWord, string toWord, int withDistance = 1)
        {
            /*
                ord1 .. ordn
                ordn.DistanceTo(ord(n-1)) = 1
                ordn.DistanceTo(toWord) = ord(n-1).DistanceTo(toWord)-1;
            */

            var d = fromWord.DistanceTo(toWord);
            var prevWord = fromWord;

            List<string> chain = new List<string> { fromWord };
            while (d > 0)
            {
                if (prevWord == default)
                {
                    return new List<string>();
                }
                prevWord = dictionary.FirstOrDefault(w => w.DistanceTo(prevWord) == 1 && w.DistanceTo(toWord) == d - 1);
                d -= 1;
                chain.Add(prevWord);
            }

            return chain;
        }


        // public static List<string> Expand(this List<string> source, List<string> dictionary, int distance)
        // {
        //     string last = source.Last();
        //     return words
        //         .Where(word => !source.Contains(word))
        //         .Where(word => word.DistanceTo(last) == distance)
        //         .Select(word => (new List<string>))
        //         .ToList();
        // }


        public static List<string> FindWordsWithDistance(this string startString, List<string> words, int distance)
        {
            return words.Where(word => word.DistanceTo(startString) == distance).ToList();
        }

        public static string ToDisplayString(this IEnumerable<string> wordChain) => string.Join(" -> ", wordChain);
    }
}
