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
        private static int _Power = 1;
        private int _power;
        private int _intVolume;

        public int Volume { get { return _intVolume; } }
        public int Power { get { return _power; } }

        public AquaVitae(AquaVitae other) : base(_Power, IsRenewable) {
            _intVolume = other.Volume;
            _power = other.Power;
        }

        public AquaVitae(Volumes volume) : base(_Power, IsRenewable)
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
            
            _power = _Power;
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

        public override string ToString() {
            return $"{this.GetType().Name} {this.Volume}";
        }

        public override bool Equals(Object obj) {
            if((obj as Artefact).ToString().Equals(this.ToString()))
                return true;
            else
                return false;
        }
    }
}