using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Spells
{
    public class Antidote : Spell
    {
        // Essentially the same thing as Heal.cs
        
        ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());

        private const double MinMana = 30;
        
        public Antidote(bool isVerbal, bool isMotional) : base(MinMana, isVerbal, isMotional) { }
        
        public override void MagicCast(Wizard wizard, Character character)
        {
            if (character.Condition == Conditions.Poisoned && wizard.CurrentMana >= MinMana)
            {
                character.Status();
                wizard.CurrentMana -= MinMana;
            }
            else if(character.Condition != Conditions.Poisoned)
            {
                throw new Exception(rm.GetString("CharacterNotPoisoned"));
            }
            else
            {
                throw new Exception(rm.GetString("LowMana"));
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (wizard.Condition == Conditions.Poisoned && wizard.CurrentMana >= MinMana)
            {
                wizard.Status();
                wizard.CurrentMana -= MinMana;
            }
            else if(wizard.Condition != Conditions.Poisoned)
            {
                throw new Exception(rm.GetString("WizardNotPoisoned"));
            }
            else
            {
                throw new Exception(rm.GetString("LowMana"));
            }
        }
    }
}