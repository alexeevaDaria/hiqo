using System;
using Xunit;
using BowlingGame;

namespace BowlingGameTDD
{
    public class ScoreTests
    {
        private Game game;
        public ScoreTests()
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
        [Fact]
        public void Score_BallCount_finalScore()
        {      
            KeepRolling(1, 20);
            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void Score_SparePoints_finalScore()
        {            
            KeepRolling(1, 16);// test method

            KeepRolling(6,1);
            KeepRolling(4,1);

            KeepRolling(3, 2);

            Assert.Equal(35, game.Score());
        }

        [Fact]
        public void Score_StrikePoints_finalScore()
        {
            KeepRolling(1, 14);
            KeepRolling(10,1);
            KeepRolling(2,1);
            KeepRolling(4,1);
            KeepRolling(1, 2);

            Assert.Equal(38, game.Score());
        }

        //bonuses
        [Fact]
        public void Score_SpareBonusPoints_finalScore()
        {

            KeepRolling(1, 18);
            KeepRolling(8,1);
            KeepRolling(2,1);
            KeepRolling(4,1);
            Assert.Equal(32, game.Score());
        }
        [Fact]
        public void Score_StrikeBonusPoints_finalScore()
        {
            KeepRolling(1, 18);
            KeepRolling(10,1);
            KeepRolling(2,1);
            KeepRolling(4,1);
            Assert.Equal(34, game.Score());
        }
        [Fact]
        public void Score_AllBonusPoints_finalScore()
        {
            KeepRolling(1, 14);
            KeepRolling(8,1);
            KeepRolling(2,1);
            KeepRolling(10,1);
            KeepRolling(9,1);
            KeepRolling(1,1);
            KeepRolling(4,1);

            Assert.Equal(68, game.Score());
        }
        

    }
}
