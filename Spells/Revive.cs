using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Spells
{
    public class Revive : Spell
    {
        // The only thing different from Heal.cs is that after revival CurrentHealth = 1.
        
        private static ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());
        
        private const double MinMana = 150;
        private bool _isVerbal;
        private bool _isMotional;

        public Revive(bool isVerbal, bool isMotional) : base(MinMana, isVerbal, isMotional)
        {
            _isVerbal = isVerbal;
            _isMotional = isMotional;
        }
        
        private bool isSpellAvailable(Wizard wizard)
        {
            if (_isVerbal && !wizard.AbilityToTalk)
            {
                Console.Error.WriteLine(rm.GetString("NoTalk"));
            }
            else if (_isMotional && !wizard.AbilityToMove)
            {
                Console.Error.WriteLine(rm.GetString("NoMotion"));
            }
            else
            {
                return true;
            }

            return false;
        }
        
        public override void MagicCast(Wizard wizard, Character character)
        {
            if (isSpellAvailable(wizard))
            {
                if (character.Condition == Conditions.Dead && wizard.CurrentMana >= MinMana)
                {
                    character.Status();
                    character.CurrentHealth = 1;
                    wizard.CurrentMana -= MinMana;
                }
                else if (character.Condition != Conditions.Dead)
                {
                    throw new Exception(rm.GetString("CharacterNotDead"));
                }
                else
                {
                    throw new Exception(rm.GetString("LowMana"));
                }
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (isSpellAvailable(wizard))
            {
                if (wizard.Condition == Conditions.Dead && wizard.CurrentMana >= MinMana)
                {
                    wizard.Status();
                    wizard.CurrentHealth = 1;
                    wizard.CurrentMana -= MinMana;
                }
                else if (wizard.Condition != Conditions.Dead)
                {
                    throw new Exception(rm.GetString("WizardNotDead"));
                }
                else
                {
                    throw new Exception(rm.GetString("CharacterNotDead"));
                }
            }
        }

        public override string ToString() {
            return $"{this.GetType().Name}";
        }

        public override bool Equals(Object obj) {
            if((obj as Revive).ToString().Equals(this.ToString()))
                return true;
            else
                return false;
        }
    }
}