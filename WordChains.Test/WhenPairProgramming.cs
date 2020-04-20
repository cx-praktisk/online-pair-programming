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

        // xUnit also supports theories, which are parameterized tests.
        // They are declared using a [Theory] attribute.
        // Every set of parameters in an [InlineData(...)] attribute, is a single test case.
        [Theory]
        [InlineData("CAT", "CUT", 1)]
        [InlineData("CAT", "PAT", 1)]
        public void DistanceBetween(string aWord, string anotherWord, int expectedDistance) =>
            aWord.DistanceTo(anotherWord).Should().Be(expectedDistance);
    }
}
