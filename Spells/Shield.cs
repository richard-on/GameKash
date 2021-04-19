namespace GameKash.Spells
{
    public class Shield : Spell, IPower
    {
        //The problem is that we need time-tracking for this method. The best idea so far is to track turns.
        //This, however, requires further discussion. For now, this class is intentionally left empty.
        //TODO: Decide how to track turns and implement this class.
        
        public Shield(double minMana, bool isVerbal, bool isMotional) : base(minMana, isVerbal, isMotional)
        {
            throw new System.NotImplementedException();
        }

        public override void MagicCast(Wizard wizard, Character character)
        {
            throw new System.NotImplementedException();
        }

        public override void MagicCast(Wizard wizard)
        {
            throw new System.NotImplementedException();
        }

        public void MagicCast(Wizard wizard, Character character, double power)
        {
            throw new System.NotImplementedException();
        }

        public void MagicCast(Wizard wizard, double power)
        {
            throw new System.NotImplementedException();
        }
    }
}