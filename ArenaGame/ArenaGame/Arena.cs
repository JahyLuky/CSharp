using System;
using System.Threading;
using objektove_programko.Characters;
using objektove_programko.Characters.Classes;

namespace arena_game
{
    class Arena
    {
        private Character fighter1;
        private Character fighter2;
        private Dice dice;

        public Arena(Character fighter1, Character fighter2, Dice dice)
        {
            this.fighter1 = fighter1;
            this.fighter2 = fighter2;
            this.dice = dice;
        }

        private void Render()
        {
            Console.Clear();
            Console.WriteLine("-------------- Arena -------------- \n");

            // Display the fighters
            DisplayFighterInfo(fighter1);
            Console.WriteLine(); // Blank line between fighters
            DisplayFighterInfo(fighter2);
        }

        private void DisplayFighterInfo(Character fighter)
        {
            // Display fighter name
            Console.WriteLine(fighter);

            // Display health bar
            Console.WriteLine($"HP: {fighter.DisplayHealth()}");

            // Display mana bar if the fighter is a Mage
            if (fighter is Mage mage)
            {
                Console.WriteLine($"Mana: {mage.DisplayMana()}");
            }
            Console.WriteLine("\n");
        }

        private void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(800);
            //Console.ReadKey();
        }

        public void Fight()
        {
            Console.Clear();
            Character f1 = fighter1;
            Character f2 = fighter2;
            Console.WriteLine("Today {0} will face off against {1}! \n", fighter1, fighter2);
            bool f2Starts = (dice.Roll() <= dice.GetNumberOfSides() / 2);
            if (f2Starts)
            {
                f1 = fighter2;
                f2 = fighter1;
            }
            Console.WriteLine("The fight will start with fighter {0}! \nThe match can begin... (press Enter)", f1);
            Console.ReadKey();
            while (f1.IsAlive() && f2.IsAlive())
            {
                f1.Attack(f2);
                Render();
                ShowMessage(f1.GetLastMessage());
                ShowMessage(f2.GetLastMessage());
                if (f2.IsAlive())
                {
                    f2.Attack(f1);
                    Render();
                    ShowMessage(f2.GetLastMessage());
                    ShowMessage(f1.GetLastMessage());
                }
                Console.WriteLine();
            }
        }
    }
}
