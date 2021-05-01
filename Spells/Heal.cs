using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Spells
{
    public class Heal : Spell
    {
        // Constructor can be implemented as follows:
        // public Heal(bool isVerbal, bool isMotional, double minMana = 20) : base(20, isVerbal, isMotional) { }
        //          or
        // public Heal(bool isVerbal, bool isMotional) : base(20, isVerbal, isMotional) { }
        // Not sure what is better.
        
        ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());

        private const double MinMana = 20;
        
        public Heal(bool isVerbal, bool isMotional) : base(MinMana, isVerbal, isMotional) { }
        
        public override void MagicCast(Wizard wizard, Character character)
        {
            if (character.Condition == Conditions.Sick && wizard.CurrentMana >= MinMana)
            {
                character.Status();
                wizard.CurrentMana -= MinMana;
            }
            else if(character.Condition != Conditions.Sick)
            {
                throw new Exception(rm.GetString("CharacterNotSick"));
            }
            else
            {
                throw new Exception(rm.GetString("LowMana"));
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (wizard.Condition == Conditions.Sick && wizard.CurrentMana >= MinMana)
            {
                wizard.Status();
                wizard.CurrentMana -= MinMana;
            }
            else if(wizard.Condition != Conditions.Sick)
            {
                throw new Exception(rm.GetString("WizardNotSick"));
            }
            else
            {
                throw new Exception(rm.GetString("LowMana"));
            }
        }

        public override string ToString() {
            return $"{this.GetType().Name}";
        }

        public override bool Equals(Object obj) {
            if((obj as Heal).ToString().Equals(this.ToString()))
                return true;
            else
                return false;
        }
    }
}