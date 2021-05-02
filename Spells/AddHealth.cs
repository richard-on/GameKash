using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Spells {
    public class AddHealth : Spell, IPower
    {
        private static ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());
        
        private const double MinMana = 0;
        private bool _isVerbal;
        private bool _isMotional;

        public AddHealth(bool isVerbal, bool isMotional) : base(MinMana, isVerbal, isMotional)
        {
            _isVerbal = isVerbal;
            _isMotional = isMotional;
        }
        
        // Exceptions are handled in respective Setters, so there is no need in any checks in MagicCast
        public void MagicCast(Wizard wizard, Character character, double healthToAdd)
        {
            if (isSpellAvailable(wizard))
            {
                wizard.CurrentMana -= healthToAdd * 2;
                character.CurrentHealth += healthToAdd;
            }
        }
        
        public override void MagicCast(Wizard wizard, Character character)
        {
            if (isSpellAvailable(wizard))
            {
                if (wizard.CurrentMana / 2 > character.MaxHealth - character.CurrentHealth)
                {
                    character.CurrentHealth = character.MaxHealth;
                    wizard.CurrentMana -= (character.MaxHealth - character.CurrentHealth) * 2;
                }
                else
                {
                    character.CurrentHealth += wizard.CurrentMana / 2;
                    wizard.CurrentMana = 0;
                }
            }
        }

        public void MagicCast(Wizard wizard, double healthToAdd)
        {
            if (isSpellAvailable(wizard))
            {
                wizard.CurrentMana -= healthToAdd * 2;
                wizard.CurrentHealth += healthToAdd;
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (isSpellAvailable(wizard))
            {
                if (wizard.CurrentMana / 2 > wizard.MaxHealth - wizard.CurrentHealth)
                {
                    wizard.CurrentMana -= (wizard.MaxHealth - wizard.CurrentHealth) * 2;
                    wizard.CurrentHealth = wizard.MaxHealth;
                }
                else
                {
                    wizard.CurrentHealth += wizard.CurrentMana / 2;
                    wizard.CurrentMana = 0;
                }
            }
        }

        public override string ToString() {
            return $"{this.GetType().Name} {this._isMotional} {this._isVerbal}";
        }

        public override bool Equals(Object obj) {
            if((obj as AddHealth).ToString().Equals(this.ToString()))
                return true;
            else
                return false;
        }
    }
}
