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

            game.KeepRolling(1, 20);
            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void Game_With_Spare_Frame()
        {
            Game game = new Game();
            game.KeepRolling(1, 16);
            
            game.Roll(6);
            game.Roll(4);

            game.KeepRolling(3, 2);

            Assert.Equal(35, game.Score());
        }

        [Fact]
        public void Game_With_Strike_Frame()
        {
            Game game = new Game();

            game.KeepRolling(1, 14);
            game.Roll(10);
            game.Roll(2);
            game.Roll(4);
            game.KeepRolling(1, 2);
            Assert.Equal(38, game.Score());
        }

        //bonuses
        [Fact]
        public void Game_With_Single_Bonus_Roll()
        {
            Game game = new Game();

            game.KeepRolling(1, 18);
            game.Roll(8);
            game.Roll(2);
            game.Roll(4);
            Assert.Equal(32, game.Score());
        }
        [Fact]
        public void Game_With_Two_Bonus_Roll()
        {
            Game game = new Game();

            game.KeepRolling(1, 18);
            game.Roll(10);
            game.Roll(2);
            game.Roll(4);
            Assert.Equal(34, game.Score());
        }
        [Fact]
        public void Game_With_All_Types_Bonuses()
        {
            Game game = new Game();

            game.KeepRolling(1, 14);
            game.Roll(8);
            game.Roll(2);
            game.Roll(10);
            game.Roll(9);
            game.Roll(1);
            game.Roll(4);

            Assert.Equal(68, game.Score());
        }
        //index
        [Fact]
        public void InvalidIndex()
        {
            Game game = new Game();

            Assert.Throws<IndexOutOfRangeException>(() => game.KeepRolling(1, 23));
        }
        [Theory]
        [InlineData(2, 10)]
        [InlineData(2, 9)]
        [InlineData(8, 8)]
        public void InvalidParameters(int points1, int points2)
        {
            Game game = new Game();

            game.Roll(points1);
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(points2));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        [InlineData(100)]
        [InlineData(Int32.MaxValue)]
        [InlineData(Int32.MinValue)]
        public void CriticalParameters(int points)
        {
            Game game = new Game();
        //    var ex = Assert.Throws<Exception>(() => game.Roll(points));
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(points));
        //    Assert.Equal("ballCount is out of range", ex.Message);

        }

    }
}
