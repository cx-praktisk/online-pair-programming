using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace WordChains.Test
{
    public class WhenPairProgramming
    {
        // Simple tests are called facts in xUnit, and are public methods marked with a [Fact] attribute.
        [Fact]
        public void DistanceBetweenCatAndCutShouldBe1()
        {
            var word = "CAT";
            var anotherWord = "CUT";

            // This test project is using Fluent Assertions (https://fluentassertions.com/introduction).
            word.DistanceTo(anotherWord).Should().Be(1);
        }

        [Fact]
        public void DistanceBetweetCatAndCogShouldBe2()
        {
            var word = "CAT";
            var anotherWord = "COG";

            // This test project is using Fluent Assertions (https://fluentassertions.com/introduction).
            word.DistanceTo(anotherWord).Should().Be(2);
        }

        [Fact]
        public void DistanceBetweetCodeAndRubyShouldBe4()
        {
            var word = "CODE";
            var anotherWord = "RUBY";

            word.DistanceTo(anotherWord).Should().Be(4);
        }

        [Fact]
        public void DistanceBetweenEqualWordsShouldBe0()
        {
            "Computas".DistanceTo("Computas").Should().Be(0);
        }

        [Fact]
        public void WordChain1()
        {
            var dictonary = new List<string>() { "CAT", "COMPUTAS", "CAG", "COG", "DOG" };
            var fromWord = "CAT";
            var toWord = "DOG";
            var wordChain = dictonary.FindWordChain(fromWord, toWord);

            wordChain.ToDisplayString().Should().Be("CAT -> CAG -> COG -> DOG");
        }

        // [Fact]
        // public void WordChain2()
        // {
        //     var dictonary = new List<string>() { "AAA", "BAC", "" };
        //     var fromWord = "AAA";
        //     var toWord = "BAC";
        //     var wordChain = dictonary.FindWordChain(fromWord, toWord);

        //     wordChain.ToDisplayString().Should().Be("AAAAA -> AAAAB -> AAABB");
        // }

        // xUnit also supports theories, which are parameterized tests.
        // They are declared using a [Theory] attribute.
        // Every set of parameters in an [InlineData(...)] attribute, is a single test case.
        [Theory]
        [InlineData("CAT", "CUT", 1)]
        [InlineData("CAT", "PAT", 1)]
        [InlineData("CAT", "DOG", 3)]
        [InlineData("COG", "CAT", 2)]
        [InlineData("COG", "COMPUTAS", -1)]
        [InlineData("COG", "COG", 0)]
        [InlineData("COG", "DOG", 1)]
        public void DistanceBetween(string aWord, string anotherWord, int expectedDistance) =>
            aWord.DistanceTo(anotherWord).Should().Be(expectedDistance);

        [Fact]
        public void TestXXX()
        {
            List<string> mathces = "COG".FindWordsWithDistance(new List<string>() { "CAT", "COMPUTAS", "CAG", "COG", "DOG" }, 1);
            mathces.Should().HaveCount(2);
            mathces.Should().Contain("DOG");
            mathces.Should().Contain("CAG");
        }
    }
}
