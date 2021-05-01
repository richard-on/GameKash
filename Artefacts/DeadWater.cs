using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Artefacts
{
    public class DeadWater : Artefact
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
        private int _power;
        private int _intVolume;

        public int Volume { get { return _intVolume; } }

        public DeadWater(Volumes volume) : base(Power, IsRenewable)
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
        
        //This class has the same problems with used items check as AquaVitae.cs
        //Moreover, this artefact can only apply to another wizard and it poses obvious problems.
        //TODO: Wisely deal with situation of one wizard adding mana to another wizard
        public override void MagicCast(Wizard issuingWizard, Character character)
        {
            if (_power > 0)
            {
                if (character is Wizard wizard)
                {
                    if (wizard.CurrentMana + _intVolume <= wizard.MaxMana)
                    {
                        wizard.CurrentMana += _intVolume;
                    }
                    else
                    {
                        wizard.CurrentMana = wizard.MaxMana;
                    }

                    _power--;
                }
                else
                {
                    throw new Exception(rm.GetString("OnlyForWizard"));
                }
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
                if (wizard.CurrentMana + _intVolume <= wizard.MaxMana)
                {
                    wizard.CurrentMana += _intVolume;
                }
                else
                {
                    wizard.CurrentMana = wizard.MaxMana;
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
            if(obj.ToString().Equals(this.ToString()))
                return true;
            else
                return false;
        }
    }
}