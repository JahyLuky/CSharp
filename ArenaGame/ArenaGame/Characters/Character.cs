using arena_game;
using System;

namespace objektove_programko.Characters
{
    class Character
    {
        protected string name;
        protected int health;
        protected int maxHealth;
        protected int attack;
        protected int defense;
        protected Dice dice;
        public string message;

        public Character(string name, int health, int attack, int defense, Dice dice)
        {
            this.name = name;
            this.health = health;
            maxHealth = health;
            this.attack = attack;
            this.defense = defense;
            this.dice = dice;
        }

        public override string ToString()
        {
            return name;
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        protected string DisplayBar(int current, int max)
        {
            string s = "[";
            int total = 20; // Length of the bar
            double count = Math.Round((double)current / max * total);
            if (count == 0 && IsAlive())
                count = 1;
            for (int i = 0; i < count; i++)
                s += "#";
            s = s.PadRight(total + 1);
            s += "]";
            return s;
        }

        public string DisplayHealth()
        {
            return DisplayBar(health, maxHealth);
        }

        public virtual void Defend(int damage)
        {
            int injury = damage - (defense + dice.Roll());
            if (injury > 0)
            {
                health -= injury;
                message = string.Format("{0} suffered {1} damage", name, injury);
                if (health <= 0)
                {
                    health = 0;
                    message += " and died";
                }
            }
        }

        public virtual void Attack(Character opponent)
        {
            int damage = attack + dice.Roll();
            SetMessage(string.Format("{0} attacks with {1} damage", name, damage));
            opponent.Defend(damage);
        }

        protected void SetMessage(string message)
        {
            this.message = message;
        }

        public string GetLastMessage()
        {
            return message;
        }
    }
}
