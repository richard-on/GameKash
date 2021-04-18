using System;

namespace GameKash.Artefacts
{
    //AquaVitae is Latin for "Living water" (if translated literally). In reality, it is basically a name for a 
    //medieval vodka. So, I believe this is the best class name I can imagine.
    public class AquaVitae : Artefact
    {
        public enum Volumes
        {
            Small = 10,
            Normal = 25,
            Large = 50
        }
        
        private const bool IsRenewable = false;
        private const int Power = 1;
        private static int _power;
        private bool isUsed = false;
        private Volumes _volume;
        private int IntVolume;

        public AquaVitae(Volumes volume) : base(Power, IsRenewable)
        {
            if (volume == Volumes.Large)
            {
                _volume = Volumes.Large;
                IntVolume = 50;
            }
            else if (volume == Volumes.Normal)
            {
                _volume = Volumes.Normal;
                IntVolume = 25;
            }
            else if (volume == Volumes.Small)
            {
                _volume = Volumes.Small;
                IntVolume = 10;
            }
            
            _power = Power;
            
        }
        
        //TODO: Implement better logic to check if the item has been used.
        public override void MagicCast(Wizard wizard, Character character)
        {
            if (_power > 0)
            {
                if (character.CurrentHealth + IntVolume <= character.MaxHealth)
                {
                    character.CurrentHealth += IntVolume;
                }
                else
                {
                    character.CurrentHealth = character.MaxHealth;
                }
                _power--;
            }
            else
            {
                throw new Exception("This artefact has already been used and can't be renewed.");
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (_power > 0)
            {
                if (wizard.CurrentHealth + IntVolume <= wizard.MaxHealth)
                {
                    wizard.CurrentHealth += IntVolume;
                }
                else
                {
                    wizard.CurrentHealth = wizard.MaxHealth;
                }
                _power--;
            }
            else
            {
                throw new Exception("This artefact has already been used and can't be renewed.");
            }
        }
    }
}