using System;
using System.Security.Cryptography;

namespace GameKash.Artefacts
{
    public class Decoction : Artefact
    {
        private const bool IsRenewable = false;
        private const int Power = 1;
        private static int _power;
        
        
        public Decoction() : base(Power, IsRenewable)
        {
            _power = Power;
        }

        public override void MagicCast(Wizard wizard, Character character)
        {
            if (character.Condition == Conditions.Poisoned && _power > 0)
            {
                character.Status();
                _power--;
            }
            else if(character.Condition != Conditions.Poisoned)
            {
                Console.Error.WriteLine("Character is not poisoned.");
            }
            else
            {
                Console.Error.WriteLine("This artefact has already been used and can't be renewed.");
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (wizard.Condition == Conditions.Poisoned && _power > 0)
            {
                wizard.Status();
                _power--;
            }
            else if(wizard.Condition != Conditions.Poisoned)
            {
                Console.Error.WriteLine("Wizard is not poisoned.");
            }
            else
            {
                Console.Error.WriteLine("This artefact has already been used and can't be renewed.");
            }
        }
    }
}