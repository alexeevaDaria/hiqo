using System;
using Xunit;
using BowlingGame;

namespace BowlingGameTDD
{
    public class RollTests
    {
        private Game game;
        public RollTests()
        {
            game = new Game();
        }
        private void KeepRolling(int value, int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                game.Roll(value);
            }
        }
        //index
        [Fact]
        public void Roll_InvalidIndex_OutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => KeepRolling(1, 23));
        }
        [Theory]
        [InlineData(2, 10)]
        [InlineData(2, 9)]
        [InlineData(8, 8)]
        public void Roll_InvalidParameters_OutOfRangeException(int points1, int points2)
        {
            KeepRolling(points1, 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(points2));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        [InlineData(100)]
        [InlineData(Int32.MaxValue)]
        [InlineData(Int32.MinValue)]
        public void Roll_CriticalParameters_OutOfRangeException(int points)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(points));


        }
    }
}
