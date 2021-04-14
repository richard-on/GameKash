using System;

namespace GameKash.Spells
{
    public class Antidote : Spell
    {
        // Essentially the same thing as Heal.cs

        private const double minMana = 30;
        
        public Antidote(bool isVerbal, bool isMotional) : base(minMana, isVerbal, isMotional) { }
        
        public override void MagicCast(Wizard wizard, Character character)
        {
            if (character.Condition == Conditions.Poisoned && wizard.CurrentMana >= minMana)
            {
                character.Status();
                wizard.CurrentMana -= minMana;
            }
            else if(character.Condition != Conditions.Poisoned)
            {
                throw new Exception("Character is not poisoned!");
            }
            else
            {
                throw new Exception("Not enough mana!");
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (wizard.Condition == Conditions.Poisoned && wizard.CurrentMana >= minMana)
            {
                wizard.Status();
                wizard.CurrentMana -= minMana;
            }
            else if(wizard.Condition != Conditions.Poisoned)
            {
                throw new Exception("Wizard is not poisoned!");
            }
            else
            {
                throw new Exception("Not enough mana!");
            }
        }
    }
}