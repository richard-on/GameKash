using GameKash.Spells;

namespace GameKash.Artefacts
{
    public abstract class Artefact : IMagic
    {
        private double _power;
        public bool _isRenewable { get; }
        
        protected Artefact(double power, bool isRenewable)
        {
        }

        public abstract void MagicCast(Wizard wizard, Character character);
        public abstract void MagicCast(Wizard wizard);
    }
}