using System;
using objektove_programko.Characters;
using objektove_programko.Characters.Classes;

namespace arena_game
{
    class Menu
    {
        public Menu() { }

        public Character Display()
        {
            Console.WriteLine("Welcome to the arena!\n");
            Console.WriteLine("We have 3 types of characters: Hunter (1), Warrior (2), or Mage (3)");
            Console.WriteLine("You will face the mage Gandalf!");
            Console.Write("Choose your character: ");

            int choice = int.Parse(Console.ReadLine());

            Console.Write("Enter your character's name: ");
            string name = Console.ReadLine();

            // Set default values for health, attack, defense, and shield (if applicable)
            int health = 100;
            int attack = 20;
            int defense = 10;
            int shield = 50; // Default shield value

            Dice gameDice = new Dice();

            Character player;
            switch (choice)
            {
                case 1:
                    // Initialize Hunter with default values
                    player = new Hunter(name, health, attack, defense, gameDice);
                    break;
                case 2:
                    // Initialize Warrior with default shield value
                    player = new Warrior(name, health, attack, defense, gameDice, shield);
                    break;
                case 3:
                    // Initialize Mage with default values
                    int mana = 10;
                    int magicAttack = 30;
                    player = new Mage(name, health, attack, defense, gameDice, mana, magicAttack);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Warrior.");
                    player = new Warrior(name, health, attack, defense, gameDice, shield);
                    break;
            }

            return player;
        }
    }
}
