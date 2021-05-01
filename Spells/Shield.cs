using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Spells
{
    public class Shield : Spell, IPower
    {
        private static ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());

        private const double MinMana = 50;
        private static int _validTurnsNum;
        private static bool _isVerbal;
        private static bool _isMotional;
        
        public Shield(bool isVerbal, bool isMotional, int turns) : base(50, isVerbal, isMotional)
        {
            _isVerbal = isVerbal;
            _isMotional = isMotional;
            _validTurnsNum = turns;
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
        
        //After trying so many times, still no idea how to track turns and implement shield(

        public override void MagicCast(Wizard wizard, Character character)
        {
            if (isSpellAvailable(wizard))
            {
                throw new System.NotImplementedException();
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (isSpellAvailable(wizard))
            {
                throw new System.NotImplementedException();
            }
        }

        public void MagicCast(Wizard wizard, Character character, double power)
        {
            if (isSpellAvailable(wizard))
            {
                throw new System.NotImplementedException();
            }
        }

        public void MagicCast(Wizard wizard, double power)
        {
            if (isSpellAvailable(wizard))
            {
                throw new System.NotImplementedException();
            }
        }

        public override string ToString() {
            return $"{this.GetType().Name}";
        }

        public override bool Equals(Object obj) {
            if((obj as Shield).ToString().Equals(this.ToString()))
                return true;
            else
                return false;
        }
    }
}