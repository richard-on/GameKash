using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Spells {
    public abstract class Spell : IMagic
    {
        private static ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());
        
        private double _minMana;
        private bool _isVerbal;
        private bool _isMotional;

        protected Spell(double minMana, bool isVerbal, bool isMotional)
        {
            _isVerbal = isVerbal;
            _isMotional = isMotional;
        }
        
        protected bool isSpellAvailable(Wizard wizard)
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
        
        public abstract void MagicCast(Wizard wizard, Character character);

        public abstract void MagicCast(Wizard wizard);
    }
}
