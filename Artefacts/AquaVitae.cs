using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Artefacts
{
    //AquaVitae is Latin for "Living water" (if translated literally). In reality, it is basically a name for a 
    //medieval vodka. So, I believe this is the best class name I can imagine.
    public class AquaVitae : Artefact
    {
        ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());
        
        public enum Volumes
        {
            Small = 10,
            Normal = 25,
            Large = 50
        }
        
        private const bool IsRenewable = false;
        private const int Power = 1;
        private static int _power;
        private static int _intVolume;

        public AquaVitae(Volumes volume) : base(Power, IsRenewable)
        {
            switch (volume)
            {
                case Volumes.Large:
                    _intVolume = 50;
                    break;
                case Volumes.Normal:
                    _intVolume = 25;
                    break;
                case Volumes.Small:
                    _intVolume = 10;
                    break;
                default:
                    _intVolume = 25;
                    break;
            }
            
            _power = Power;
        }
        
        //TODO: Implement better logic to check if the item has been used.
        public override void MagicCast(Wizard wizard, Character character)
        {
            if (_power > 0)
            {
                if (character.CurrentHealth + _intVolume <= character.MaxHealth)
                {
                    character.CurrentHealth += _intVolume;
                }
                else
                {
                    character.CurrentHealth = character.MaxHealth;
                }
                _power--;
            }
            else
            {
                throw new Exception(rm.GetString("IsNotRenewable"));
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (_power > 0)
            {
                if (wizard.CurrentHealth + _intVolume <= wizard.MaxHealth)
                {
                    wizard.CurrentHealth += _intVolume;
                }
                else
                {
                    wizard.CurrentHealth = wizard.MaxHealth;
                }
                _power--;
            }
            else
            {
                throw new Exception(rm.GetString("IsNotRenewable"));
            }
        }

    }
}