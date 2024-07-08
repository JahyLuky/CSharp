using System;

namespace arena_game
{
    class Dice
    {
        private Random random;
        private int numberOfSides;

        public Dice()
        {
            numberOfSides = 10;
            random = new Random();
        }

        public Dice(int numberOfSides)
        {
            this.numberOfSides = numberOfSides;
            random = new Random();
        }

        public int GetNumberOfSides()
        {
            return numberOfSides;
        }

        public int Roll()
        {
            return random.Next(1, numberOfSides + 1);
        }

        public override string ToString()
        {
            return String.Format("Dice with {0} sides", numberOfSides);
        }
    }
}
