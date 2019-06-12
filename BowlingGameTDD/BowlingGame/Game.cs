using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
    public class Game
    {
        int currentIndex = 0;
        public int[] rolls = new int[22];
        public int this[int index]
        {
            set
            {
                if (index < rolls.Length && index >= 0)
                    rolls[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }

            get
            {
                return (index < rolls.Length && index >= 0) ? rolls[index] : throw new IndexOutOfRangeException();
            }
        }
        public void Roll( int ballCount)
        {
            
            if (ballCount <= 10 && ballCount >= 0)
                if((currentIndex % 2 != 0 && (ballCount>10-rolls[currentIndex - 1])))
                    throw new ArgumentOutOfRangeException("second roll in a frame must be less or equal to (10 - ballCount)");
                else if (ballCount == 10)
                {
                    rolls[currentIndex] = ballCount;
                    currentIndex += 2;
                }                  
                else
                    rolls[currentIndex++] = ballCount;
            else
                throw new ArgumentOutOfRangeException("ballCount must be in between [0,10]");
        }
        public void KeepRolling(int value, int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                Roll(value);
            }
        }

        
        //1 spare 2 strike
        public int Score()
        {
            int finalScore = 0;
            int frameNumber = 0;
            for(int frame=0; frame<10; frame++)
            {
                if(rolls[frameNumber]==10)//strike
                {
                    finalScore += 10 + BonusPoints(frameNumber, 2);
                    frameNumber += 2;
                }
                else if (rolls[frameNumber] + rolls[frameNumber + 1] == 10) // spare
                {
                    finalScore += 10 + BonusPoints(frameNumber, 1);
                    frameNumber += 2;
                }
                else
                {
                    finalScore += rolls[frameNumber] + rolls[frameNumber + 1];
                    frameNumber += 2;
                }
            }
            return finalScore;
        }

        public int BonusPoints(int index, int state)
        {
            int bonusPoints = 0;
            //state and  index check
            switch (state)
            {
                case 1:
                    bonusPoints = rolls[index + 2];
                    break;
                case 2:
                    bonusPoints = rolls[index + 2] + rolls[index + 3];
                    break;
            }
            return bonusPoints;
        }
    }

   
}
