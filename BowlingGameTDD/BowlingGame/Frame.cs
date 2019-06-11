using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
    class Frame
    {
        static string[] States = { "none", "spare", "strike" };
        // public int score;
        private int firstTry, secondTry;
        int numberOfTry;
        public int state = 0;

        public int FirstTry
        {
            get
            {
                return firstTry;
            }
            set
            {
                firstTry = value;
                if (value == 10)
                {
                    state = 2;
                    SecondTry = 0;
                    numberOfTry = 2;
                }
            }
        }

        public int SecondTry
        {
            get
            {
                return secondTry;
            }
            set
            {
                secondTry = value;
                if ((secondTry + firstTry) == 10)
                    state = 1;
            }
        }
    }
}
