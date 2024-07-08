using System;
using arena_game;
using objektove_programko.Characters;

namespace objektove_programko.Characters.Classes
{
    class Mage : Character
    {
        private int mana;
        private int maxMana;
        private int magicAttack;

        public Mage(string name, int health, int attack, int defense, Dice dice, int mana, int magicAttack)
            : base(name, health, attack, defense, dice)
        {
            this.mana = mana;
            maxMana = mana;
            this.magicAttack = magicAttack;
        }

        public override void Attack(Character opponent)
        {
            int damage = 0;
            if (mana < maxMana)
            {
                mana += 5;
                if (mana > maxMana)
                    mana = maxMana;
                damage = attack + dice.Roll();
                SetMessage(string.Format("{0} attacks with {1} damage", name, damage));
            }
            else
            {
                damage = magicAttack + dice.Roll();
                SetMessage(string.Format("{0} used magic for {1} damage", name, damage));
                mana = 0;
            }
            opponent.Defend(damage);
        }

        public string DisplayMana()
        {
            return DisplayBar(mana, maxMana);
        }
    }
}
