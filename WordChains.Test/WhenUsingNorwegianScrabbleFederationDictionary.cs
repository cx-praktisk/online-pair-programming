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

        [Fact]
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

        [Theory]
        [InlineData("ABER", "ABBA", 1)]
        [InlineData("ENDER", "AKKAR", 1)]
        [InlineData("TENKE", "BANJO", 1)]
        [InlineData("SOMMER", "BOKMÅL", 1)]
        [InlineData("PARKETT", "AGITERE", 3)]
        [InlineData("ENDETARMSÅPNINGEN", "HELHETSTENKNINGER", 7)]
        public void ShouldFindWordChain(string fromWord, string toWord, int withDistance) =>
            _dictionary
                .FindWordChain(fromWord, toWord, withDistance)
                .Should()
                .NotBeEmpty(because: $"There should exist a word chain from { fromWord } to { toWord }");

        [Theory]
        [InlineData("OVERINGENIØRENE", "OLIGARKISTSKHET", 1)]
        public void ShouldNotFindWordChain(string fromWord, string toWord, int withDistance) =>
            _dictionary
                .FindWordChain(fromWord, toWord, withDistance)
                .Should()
                .BeNull(because: $"There should not exist a word chain from { fromWord } to { toWord }");
    }
}
