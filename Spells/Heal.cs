using System;

namespace GameKash.Spells
{
    public class Heal : Spell
    {
        // Constructor can be implemented as follows:
        // public Heal(bool isVerbal, bool isMotional, double minMana = 20) : base(20, isVerbal, isMotional) { }
        //          or
        // public Heal(bool isVerbal, bool isMotional) : base(20, isVerbal, isMotional) { }
        // Not sure what is better.

        private const double minMana = 20;
        
        public Heal(bool isVerbal, bool isMotional) : base(minMana, isVerbal, isMotional) { }
        
        public override void MagicCast(Wizard wizard, Character character)
        {
            if (character.Condition == Conditions.Sick && wizard.CurrentMana >= minMana)
            {
                character.Status();
                wizard.CurrentMana -= minMana;
            }
            else if(character.Condition != Conditions.Sick)
            {
                throw new Exception("Character is not sick!");
            }
            else
            {
                throw new Exception("Not enough mana!");
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (wizard.Condition == Conditions.Sick && wizard.CurrentMana >= minMana)
            {
                wizard.Status();
                wizard.CurrentMana -= minMana;
            }
            else if(wizard.Condition != Conditions.Sick)
            {
                throw new Exception("Wizard is not sick!");
            }
            else
            {
                throw new Exception("Not enough mana!");
            }
        }
    }
}