using System;

namespace GameKash.Spells
{
    public class Revive : Spell
    {
        // The only thing different from Heal.cs is that after revival CurrentHealth = 1.
        
        private const double minMana = 150;
        
        public Revive(bool isVerbal, bool isMotional) : base(minMana, isVerbal, isMotional) { }
        
        public override void MagicCast(Wizard wizard, Character character)
        {
            if (character.Condition == Conditions.Dead && wizard.CurrentMana >= minMana)
            {
                character.Status();
                character.CurrentHealth = 1;
                wizard.CurrentMana -= minMana;
            }
            else if(character.Condition != Conditions.Dead)
            {
                throw new Exception("Character is not dead!");
            }
            else
            {
                throw new Exception("Not enough mana!");
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (wizard.Condition == Conditions.Dead && wizard.CurrentMana >= minMana)
            {
                wizard.Status();
                wizard.CurrentHealth = 1;
                wizard.CurrentMana -= minMana;
            }
            else if(wizard.Condition != Conditions.Dead)
            {
                throw new Exception("Wizard is not dead!");
            }
            else
            {
                throw new Exception("Not enough mana!");
            }
        }
    }
}