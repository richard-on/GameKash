using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Spells
{
    public class Unrestrict : Spell
    {
        // Essentially the same thing as Revive.cs
        
        ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());
        
        private const double MinMana = 85;
        
        public Unrestrict(bool isVerbal, bool isMotional) : base(MinMana, isVerbal, isMotional) { }
        
        public override void MagicCast(Wizard wizard, Character character)
        {
            if (character.Condition == Conditions.Paralyzed && wizard.CurrentMana >= MinMana)
            {
                character.Status();
                character.CurrentHealth = 1;
                wizard.CurrentMana -= MinMana;
            }
            else if(character.Condition != Conditions.Paralyzed)
            {
                throw new Exception(rm.GetString("CharacterNotParalysed"));
            }
            else
            {
                throw new Exception(rm.GetString("LowMana"));
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (wizard.Condition == Conditions.Paralyzed && wizard.CurrentMana >= MinMana)
            {
                wizard.Status();
                wizard.CurrentHealth = 1;
                wizard.CurrentMana -= MinMana;
            }
            else if(wizard.Condition != Conditions.Paralyzed)
            {
                throw new Exception(rm.GetString("WizardNotParalysed"));
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
            if((obj as Unrestrict).ToString().Equals(this.ToString()))
                return true;
            else
                return false;
        }
    }
}