namespace GameKash.Spells {
    public abstract class Spell : IMagic
    {
        private double _minMana;
        private bool _isVerbal;
        private bool _isMotional;

        protected Spell(double minMana, bool isVerbal, bool isMotional)
        {
        }
        
        public abstract void MagicCast(Wizard wizard, Character character);

        public abstract void MagicCast(Wizard wizard);
    }
}
