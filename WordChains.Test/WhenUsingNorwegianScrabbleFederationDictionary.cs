using System.Linq;
using FluentAssertions;
using Xunit;

namespace WordChains.Test
{
    public class WhenUsingNorwegianScrabbleFederationDictionary
    {
        private readonly string[] _dictionary;

        public WhenUsingNorwegianScrabbleFederationDictionary()
        {
            var options = new CommandLineOptions { DictionaryFile = "norwegian-scrabble-federation-dictionary.txt" };
            _dictionary = options.Dictionary.ToArray();
        }

        // You can skip facts, by including a Skip parameter to the [Fact(...)] attribute.
        // To start executing a skipped fact, you simply change the attribute back to [Fact].
        [Fact(Skip="this until you want to test spesific words against the scrabble dictionary")]
        public void ShouldFindSpecificWordChainAndDisplayResult()
        {
            var options = new CommandLineOptions
            {
                DictionaryFile = "norwegian-scrabble-federation-dictionary.txt",
                From = "ABER",
                To = "ABBA",
                Distance = 1
            };

            Program.FindWordChain(options).Should().Be(0);
        }

        // You can also skip theories. Again you can execute the theory be changing the attribute to [Theory]
        [Theory(Skip="this until you think you've got a complete solution")]
        [InlineData("ABER", "ABBA")]
        [InlineData("ENDER", "AKKAR")]
        [InlineData("TENKE", "BANJO")]
        [InlineData("SOMMER", "BOKMÅL")]
        public void ShouldFindWordChainWithOneLetterDistance(string fromWord, string toWord) =>
            _dictionary
                .FindWordChain(fromWord, toWord, withDistance: 1)
                .Should()
                .NotBeEmpty(because: $"There should exist a word chain from { fromWord } to { toWord }");

        [Theory(Skip = "this until you think you've got a complete solution")]
        [InlineData("OVERINGENIØRENE", "OLIGARKISTSKHET", 1)]
        public void ShouldNotFindWordChain(string fromWord, string toWord, int withDistance) =>
            _dictionary
                .FindWordChain(fromWord, toWord, withDistance)
                .Should()
                .BeNull(because: $"There should not exist a word chain from { fromWord } to { toWord }");

        [Theory(Skip = "this until you have implemented variable distance between words")]
        [InlineData("SOMMER", "BOKMÅL", 1)]
        [InlineData("PARKETT", "AGITERE", 3)]
        [InlineData("ENDETARMSÅPNINGEN", "HELHETSTENKNINGER", 7)]
        public void ShouldFindWordChain(string fromWord, string toWord, int withDistance) =>
            _dictionary
                .FindWordChain(fromWord, toWord, withDistance)
                .Should()
                .NotBeEmpty(because: $"There should exist a word chain from { fromWord } to { toWord }");
    }
}
