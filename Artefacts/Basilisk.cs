using System;
using System.Reflection;
using System.Resources;

namespace GameKash.Artefacts
{
    public class Basilisk : Artefact
    {
        ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());
        
        private const bool IsRenewable = false;
        private const int Power = 1;
        private static int _power;
        
        public Basilisk() : base(Power, IsRenewable)
        {
            _power = Power;
        }

        public override void MagicCast(Wizard wizard, Character character)
        {
            if (character.Condition != Conditions.Dead && _power > 0)
            {
                character.Condition = Conditions.Paralyzed;
                _power--;
            }
            else if(character.Condition != Conditions.Poisoned)
            {
                Console.Error.WriteLine(rm.GetString("CharacterNotPoisoned"));
            }
            else
            {
                Console.Error.WriteLine(rm.GetString("IsNotRenewable"));
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (wizard.Condition == Conditions.Poisoned && _power > 0)
            {
                wizard.Condition = Conditions.Paralyzed;
                _power--;
            }
            else if(wizard.Condition != Conditions.Poisoned)
            {
                Console.Error.WriteLine(rm.GetString("WizardNotPoisoned"));
            }
            else
            {
                Console.Error.WriteLine(rm.GetString("IsNotRenewable"));
            }
        }

        public override string ToString() {
            return $"{this.GetType().Name}";
        }

        public override bool Equals(Object obj) {
            if(obj.ToString() == this.ToString())
                return true;
            else
                return false;
        }

    }
}