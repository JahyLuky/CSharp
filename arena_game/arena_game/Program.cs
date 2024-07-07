using System;
using objektove_programko.Characters;
using objektove_programko.Characters.Classes;

namespace arena_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Character player = menu.Display();

            Dice gameDice = new Dice();

            Character gandalf = new Mage("Gandalf", 100, 20, 10, gameDice, 20, 30);

            Arena arena = new Arena(player, gandalf, gameDice);

            arena.Fight();
        }
    }
}
