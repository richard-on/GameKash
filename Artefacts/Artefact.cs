namespace GameKash.Artefacts
{
    public abstract class Artefact : IArtefact
    {
        private double power;
        private bool isRenewable;
        
        protected Artefact(double power, bool isRenewable)
        {
            this.power = power;
            this.isRenewable = isRenewable;
        }
        
        public abstract void ArtefactCast(Wizard wizard, Character character);

        public abstract void ArtefactCast(Wizard wizard);
    }
}