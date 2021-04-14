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
        private const int Power = 0;
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
            
        }
        
        //TODO: Implement better logic to check if the item has been used.
        public override void ArtefactCast(Wizard wizard, Character character)
        {
            if (!isUsed)
            {
                if (character.CurrentHealth + IntVolume <= character.MaxHealth)
                {
                    character.CurrentHealth += IntVolume;
                }
                else
                {
                    character.CurrentHealth = character.MaxHealth;
                }
                isUsed = true;
            }
            else
            {
                throw new Exception("This artefact has already been used and can't be renewed.");
            }
        }

        public override void ArtefactCast(Wizard wizard)
        {
            if (!isUsed)
            {
                if (wizard.CurrentHealth + IntVolume <= wizard.MaxHealth)
                {
                    wizard.CurrentHealth += IntVolume;
                }
                else
                {
                    wizard.CurrentHealth = wizard.MaxHealth;
                }
                isUsed = true;
            }
            else
            {
                throw new Exception("This artefact has already been used and can't be renewed.");
            }
        }
    }
}