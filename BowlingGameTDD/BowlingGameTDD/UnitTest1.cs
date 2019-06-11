using System;
using Xunit;
using BowlingGame;

namespace BowlingGameTDD
{
    public class UnitTest1
    {
        /*
         * получить скор 10 раз 
         * проверка на значение рола
         * 
         */
        [Fact]
        public void BasicScore()
        {
            Game game = new Game();

            KeepRolling(game, 1, 20);
            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void RoundWithSpareFrame()
        {
            Game game = new Game();
            KeepRolling(game, 1, 16);

            game.Roll(6);
            game.Roll(4);
            game.Roll(3);
            game.Roll(3);
            Assert.Equal(35, game.Score());
        }

        private void KeepRolling(Game g, int value, int rounds)
        {
            for(int i=0; i < rounds; i++)
            {
                g.Roll(value);
            }
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        [InlineData(100)]
        [InlineData(Int32.MaxValue)]
        [InlineData(Int32.MinValue)]
        public void InvalidParameters(int points)
        {
            Game game = new Game();
        //    var ex = Assert.Throws<Exception>(() => game.Roll(points));
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(points));
        //    Assert.Equal("ballCount is out of range", ex.Message);

        }

    }
}
