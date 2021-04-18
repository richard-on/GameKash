namespace GameKash.Artefacts
{
    public abstract class Artefact : IMagic
    {
        private double _power;
        private bool _isRenewable;
        
        protected Artefact(double power, bool isRenewable)
        {
            _power = power;
            _isRenewable = isRenewable;
        }
        
        /*public abstract void MagicCast(Wizard wizard, Character character, double power);
        public abstract void MagicCast(Wizard wizard, double power);*/
        public abstract void MagicCast(Wizard wizard, Character character);
        public abstract void MagicCast(Wizard wizard);
    }
}