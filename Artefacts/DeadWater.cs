using System;
using System.Diagnostics;

namespace GameKash.Artefacts
{
    public class DeadWater : Artefact
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

        public DeadWater(Volumes volume) : base(Power, IsRenewable)
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
        
        //This class has the same problems with used items check as AquaVitae.cs
        //Moreover, this artefact can only apply to another wizard and it poses obvious problems.
        //TODO: Wisely deal with situation of one wizard adding mana to another wizard
        public override void MagicCast(Wizard issuingWizard, Character character)
        {
            if (_power > 0)
            {
                if (character is Wizard wizard)
                {
                    if (wizard.CurrentMana + IntVolume <= wizard.MaxMana)
                    {
                        wizard.CurrentMana += IntVolume;
                    }
                    else
                    {
                        wizard.CurrentMana = wizard.MaxMana;
                    }

                    _power--;
                }
                else
                {
                    throw new Exception("This artefact can only be applied to a wizard.");
                }
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
                if (wizard.CurrentMana + IntVolume <= wizard.MaxMana)
                {
                    wizard.CurrentMana += IntVolume;
                }
                else
                {
                    wizard.CurrentMana = wizard.MaxMana;
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