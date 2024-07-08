using System;
using arena_game;

namespace objektove_programko.Characters.Classes
{
    class Hunter : Character
    {
        public Hunter(string name, int health, int attack, int defense, Dice dice)
            : base(name, health, attack, defense, dice)
        {
        }

        public override void Defend(int attackPower)
        {
            if (dice.Roll() % 3 == 0)
            {
                message = string.Format("{0} dodged the attack", name);
                SetMessage(message);
            }
            else
            {
                int damage = attackPower - (defense + dice.Roll());
                if (damage > 0)
                {
                    health -= damage;
                    message = string.Format("{0} took {1} damage", name, damage);
                    if (health <= 0)
                    {
                        health = 0;
                        message += " and died";
                    }
                }
            }
        }
    }
}
