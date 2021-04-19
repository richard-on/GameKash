using GameKash.Spells;

namespace GameKash.Artefacts
{
    public abstract class Artefact : IMagic
    {

        protected Artefact(double power, bool isRenewable)
        {
        }

        public abstract void MagicCast(Wizard wizard, Character character);
        public abstract void MagicCast(Wizard wizard);
    }
}