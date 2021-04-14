using System;
using System.Collections.Generic;
using System.Text;
using GameKash.Spells;

namespace GameKash {
    public abstract class Spell : IMagic
    {
        private double minMana;
        private bool isVerbal;
        private bool isMotional;

        protected Spell(double minMana, bool isVerbal, bool isMotional)
        {
            this.minMana = minMana;
            this.isVerbal = isVerbal;
            this.isMotional = isMotional;
        }
        
        public abstract void MagicCast(Wizard wizard, Character character);

        public abstract void MagicCast(Wizard wizard);
    }
}
