using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Spells
{
    public class Unrestrict : Spell
    {
        // Essentially the same thing as Revive.cs
        
        private static ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());
        
        private const double MinMana = 85;
        private static bool _isVerbal;
        private static bool _isMotional;

        public Unrestrict(bool isVerbal, bool isMotional) : base(MinMana, isVerbal, isMotional)
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
                if (character.Condition == Conditions.Paralyzed && wizard.CurrentMana >= MinMana)
                {
                    character.Status();
                    character.CurrentHealth = 1;
                    wizard.CurrentMana -= MinMana;
                }
                else if (character.Condition != Conditions.Paralyzed)
                {
                    throw new Exception(rm.GetString("CharacterNotParalysed"));
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
                if (wizard.Condition == Conditions.Paralyzed && wizard.CurrentMana >= MinMana)
                {
                    wizard.Status();
                    wizard.CurrentHealth = 1;
                    wizard.CurrentMana -= MinMana;
                }
                else if (wizard.Condition != Conditions.Paralyzed)
                {
                    throw new Exception(rm.GetString("WizardNotParalysed"));
                }
                else
                {
                    throw new Exception(rm.GetString("LowMana"));
                }
            }
        }
    }
}