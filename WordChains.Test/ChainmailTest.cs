using System;
using System.IO;
using System.Linq;
using Xunit;

namespace WordChains.Test
{
    public class ChainmailTest
    {
        [Theory]
        [InlineData("AA", "AB", 1)]
        [InlineData("AA", "BB", 2)]
        [InlineData("BBBB", "BBBA", 1)]
        [InlineData("BbBb", "BbBA", 1)]
        [InlineData("ABBA", "BBBA", 1)]
        [InlineData("TEODOR", "MONIKA", 6)]
        public void DistanceTheory(string word, string anotherWord, int distance)
        {
            Assert.Equal(distance, word.Distance(anotherWord));
        }

        [Theory]
        [InlineData("AA", new string[] { "AB", "BX", "DE" }, 1, "AB")]
        [InlineData("aa", new string[] { "ab", "bx", "de" }, 1, "ab")]
        [InlineData("AAAA", new string[] { "ABAA", "ABA", "AADA" }, 1, "AADA")]
        [InlineData("CAT", new string[] { "CAT", "COT", "COG", "DOG", "SOG", "TOLONG" }, 1, "COT")]
        public void WithDistanceFromTheory(string word, string[] dictionary, int distance, string shouldContain)
        {
            Assert.Contains(shouldContain, dictionary.WithDistanceFrom(word, distance));
        }

        [Theory]
        [InlineData(new string[] { "AA" }, "AA", "AA", 1, "AA")]
        [InlineData(new string[] { "AB", "BB" }, "AA", "BB", 1, "AA -> AB -> BB")]
        [InlineData(new string[] { "CAT", "COT", "COG", "DOG", "SOG", "TOLONG" }, "CAT", "DOG", 1, "CAT -> COT -> COG -> DOG")]
        [InlineData(new string[] { "RUBY", "RUBS", "ROBS", "RODS", "RODE", "CODE" }, "RUBY", "CODE", 1, "RUBY -> RUBS -> ROBS -> RODS -> RODE -> CODE")]
        public void ChainWithDistanceToTheory(string[] dictionary, string word, string anotherWord, int distance, string chain)
        {
            Assert.Equal(chain, dictionary.ChainWithDistanceTo(word, anotherWord, distance));
        }

        [Theory]
        [InlineData("ABER", "ABBA", 1, "ABER -> AGER -> AGAR -> AFAR -> AVAR -> AVAL -> ANAL -> ANGL -> ANGA -> AGGA -> AGNA -> AGNE -> AKNE -> AKKE -> AKKA -> AKSA -> AKSE -> AKME -> AKRE -> ACRE -> AURE -> AUKE -> ALKE -> ALGE -> ALGI -> ANGI -> ANGE -> ANDE -> ANDA -> ANKA -> ALKA -> ALBA -> ABBA")]
        public void ChainToTheory(string word, string anotherWord, int distance, string chain)
        {
            var dictionary = File
                .ReadLines("norsk-scrabbleforbund-ordliste.txt")
                .Select(w => w.ToUpper())
                .Select(w => w.Trim())
                .Where(w => w != string.Empty);

            var actual = dictionary.ChainWithDistanceTo(word, anotherWord, distance);
            var chainLength = actual.Split("->").Count();

            Assert.Equal(chain, actual);
        }

        [Theory]
        [InlineData("ABER", "ABBA", 1)]
        [InlineData("ABER", "ABBA", 3)]
        public void ChainToFun(string word, string anotherWord, int distance)
        {
            var dictionary = File
                .ReadLines("norsk-scrabbleforbund-ordliste.txt")
                .Select(w => w.ToUpper())
                .Select(w => w.Trim())
                .Where(w => w != string.Empty);

            var actual = dictionary.ChainWithDistanceTo(word, anotherWord, distance);
            var chainLength = actual.Split("->").Count();
            Console.WriteLine($"\nFound chain!\n Chain length: {chainLength}\n Chain: {actual}\n");

            Assert.True(true);
        }
    }
}
