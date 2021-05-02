using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Spells
{
    public class Shield : Spell, IPower
    {
        private static ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());

        private const double MinMana = 50;
        private int _validTurnsNum;
        private bool _isVerbal;
        private bool _isMotional;
        
        public Shield(bool isVerbal, bool isMotional) : base(50, isVerbal, isMotional)
        {
            _isVerbal = isVerbal;
            _isMotional = isMotional;
        }

        // Shield time is counted by the number of hits. So, if you have 3 _validTurnsNum, it means your character can
        // handle 3 more hits of any power without taking any damage. This logic is further implemented in Character.cs
        // CurrentHealth setter

        public override void MagicCast(Wizard wizard, Character character)
        {
            if (isSpellAvailable(wizard))
            {
                if (wizard.CurrentMana >= MinMana)
                {
                    character.IsShieldActivated = true;
                    character.ShieldTimeLeft = (int)(wizard.CurrentMana / MinMana);
                }
                else
                {
                    Console.Error.WriteLine(rm.GetString("InvalidPowerValue"));
                }
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (isSpellAvailable(wizard))
            {
                if (wizard.CurrentMana >= MinMana)
                {
                    wizard.IsShieldActivated = true;
                    wizard.ShieldTimeLeft = (int)(wizard.CurrentMana / MinMana);
                }
                else
                {
                    Console.Error.WriteLine(rm.GetString("InvalidPowerValue"));
                }
            }
        }

        public void MagicCast(Wizard wizard, Character character, double power)
        {
            if (isSpellAvailable(wizard))
            {
                if (power >= MinMana && power % MinMana == 0 && wizard.CurrentMana >= power)
                {
                    character.IsShieldActivated = true;
                    character.ShieldTimeLeft = (int)(power / MinMana);
                }
                else
                {
                    Console.Error.WriteLine(rm.GetString("InvalidPowerValue"));
                }
            }
        }

        public void MagicCast(Wizard wizard, double power)
        {
            if (isSpellAvailable(wizard))
            {
                if (power >= MinMana && power % MinMana == 0 && wizard.CurrentMana >= power)
                {
                    wizard.IsShieldActivated = true;
                    wizard.ShieldTimeLeft = (int)(power / MinMana);
                }
                else
                {
                    Console.Error.WriteLine(rm.GetString("InvalidPowerValue"));
                }
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