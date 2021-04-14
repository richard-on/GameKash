using System;

namespace GameKash.Spells
{
    public class Unrestrict : Spell
    {
        // // Essentially the same thing as Revive.cs
        
        private const double minMana = 85;
        
        public Unrestrict(bool isVerbal, bool isMotional) : base(minMana, isVerbal, isMotional) { }
        
        public override void MagicCast(Wizard wizard, Character character)
        {
            if (character.Condition == Conditions.Paralyzed && wizard.CurrentMana >= minMana)
            {
                character.Status();
                character.CurrentHealth = 1;
                wizard.CurrentMana -= minMana;
            }
            else if(character.Condition != Conditions.Paralyzed)
            {
                throw new Exception("Character is not paralyzed!");
            }
            else
            {
                throw new Exception("Not enough mana!");
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (wizard.Condition == Conditions.Paralyzed && wizard.CurrentMana >= minMana)
            {
                wizard.Status();
                wizard.CurrentHealth = 1;
                wizard.CurrentMana -= minMana;
            }
            else if(wizard.Condition != Conditions.Paralyzed)
            {
                throw new Exception("Wizard is not paralyzed!");
            }
            else
            {
                throw new Exception("Not enough mana!");
            }
        }
    }
}