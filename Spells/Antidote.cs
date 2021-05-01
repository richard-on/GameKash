using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Spells
{
    public class Antidote : Spell
    {
        // Essentially the same thing as Heal.cs
        
        private static ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());

        private const double MinMana = 30;
        private bool _isVerbal;
        private bool _isMotional;

        public Antidote(bool isVerbal, bool isMotional) : base(MinMana, isVerbal, isMotional)
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
                if (character.Condition == Conditions.Poisoned && wizard.CurrentMana >= MinMana)
                {
                    character.Status();
                    wizard.CurrentMana -= MinMana;
                }
                else if (character.Condition != Conditions.Poisoned)
                {
                    throw new Exception(rm.GetString("CharacterNotPoisoned"));
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
                if (wizard.Condition == Conditions.Poisoned && wizard.CurrentMana >= MinMana)
                {
                    wizard.Status();
                    wizard.CurrentMana -= MinMana;
                }
                else if (wizard.Condition != Conditions.Poisoned)
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
}