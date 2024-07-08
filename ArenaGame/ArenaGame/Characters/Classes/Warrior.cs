using arena_game;
using System;

namespace objektove_programko.Characters.Classes
{
    class Warrior : Character
    {
        private int shield;
        private int maxShield;
        private Dice dice; // Ensure this is available for rolling

        public Warrior(string name, int health, int attack, int defense, Dice dice, int shield)
            : base(name, health, attack, defense, dice)
        {
            this.shield = shield;
            this.maxShield = shield;
            this.dice = dice; // Initialize the dice for rolling
        }

        // Override Defend method to include shield mechanics
        public override void Defend(int damage)
        {
            // 50% chance to use shield
            bool useShield = dice.Roll() <= dice.GetNumberOfSides() / 2;

            int shieldProtection = 0;

            if (useShield)
            {
                // Roll for shield effectiveness (5% to 35%)
                int shieldEffectiveness = 5 + dice.Roll() % 31; // Ensures range between 5% and 35%
                shieldProtection = (int)(damage * (shieldEffectiveness / 100.0)); // Calculate blocked damage

                // Ensure shield protection doesn't exceed current shield
                shieldProtection = Math.Min(shieldProtection, shield);

                // Apply shield protection to damage
                damage -= shieldProtection;

                // Decrease shield by the protection amount
                shield -= shieldProtection;

                // Ensure shield doesn't go below zero
                if (shield < 0) shield = 0;

                // Provide feedback on shield use
                if (damage > 0)
                {
                    SetMessage($"{name}'s shield blocked {shieldProtection} damage. {name} suffered {damage} damage.");
                }
                else
                {
                    SetMessage($"{name}'s shield blocked {shieldProtection} damage. No damage was suffered.");
                }
            }
            else
            {
                // If shield is not used, just calculate the damage
                int injury = damage - (defense + dice.Roll());
                if (injury > 0)
                {
                    health -= injury;
                    SetMessage($"{name} suffered {injury} damage.");
                    if (health <= 0)
                    {
                        health = 0;
                        SetMessage($"{name} died.");
                    }
                }
                else
                {
                    SetMessage($"{name} absorbed the damage with their defense.");
                }
            }
        }

        public string DisplayShield()
        {
            return DisplayBar(shield, maxShield);
        }
    }
}
