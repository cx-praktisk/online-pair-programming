using FluentAssertions;
using Xunit;

namespace WordChains.Test
{
    public class WhenPairProgramming
    {
        [Fact]
        public void DistanceBetweenCatAndCutShouldBe1()
        {
            var word = "CAT";
            var anotherWord = "CUT";

            word.DistanceTo(anotherWord).Should().Be(1);
        }

        [Theory]
        [InlineData("CAT", "CUT", 1)]
        [InlineData("CAT", "PAT", 1)]
        public void DistanceBetween(string aWord, string anotherWord, int expectedDistance) =>
            aWord.DistanceTo(anotherWord).Should().Be(expectedDistance);
    }
}
