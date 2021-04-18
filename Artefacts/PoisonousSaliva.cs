using System;
using GameKash.Spells;

namespace GameKash.Artefacts
{
    public class PoisonousSaliva : Artefact, IPower
    {
        private const bool IsRenewable = true;
        private static double _power;
        
        
        public PoisonousSaliva(double power) : base(power, IsRenewable)
        {
            _power = power;
        }
        
        private bool IsValidInput(double power)
        {
            if (_power < 0)
            {
                Console.Error.WriteLine("This artefact can't be used. This item's power is 0.");
                return false;
            }
            if (power < 0)
            {
                throw new ArgumentException("Entered power value is invalid.");
            }
            if (power > _power)
            {
                Console.Error.WriteLine($"This artefact hasn't got enough power to proceed. Available power is {_power}." +
                                        $" Specified power is {power}.");
                return false;
            }

            return true;
        }

        public void MagicCast(Wizard wizard, Character character, double power)
        {
            if (IsValidInput(power))
            {
                if (character.CurrentHealth >= power)
                {
                    character.CurrentHealth -= power;
                    _power -= power;
                    character.Condition = Conditions.Poisoned;
                }
                else
                {
                    character.CurrentHealth = 0;
                    _power = power - character.CurrentHealth;
                    character.Condition = Conditions.Dead;
                }
            }
        }

        public void MagicCast(Wizard wizard, double power)
        {
            if (IsValidInput(power))
            {
                Console.Error.WriteLine("Warning! You are about to cast this spell on your hero." +
                                        " This will decrease your OWN hero's health. Type \"Y\" if you wish to proceed." +
                                        "Type \"N\" if you wish to discard this action.");
                string answer = Console.ReadLine();
                do
                {
                    if (answer.ToUpper() == "Y")
                    {
                        if (wizard.CurrentHealth >= power)
                        {
                            wizard.CurrentHealth -= power;
                            _power -= power;
                            wizard.Condition = Conditions.Poisoned;
                        }
                        else
                        {
                            _power -= wizard.CurrentHealth;
                            wizard.CurrentHealth = 0;
                            wizard.Condition = Conditions.Dead;
                        }
                    }
                    else if(answer.ToUpper() == "N")
                    {
                        Console.WriteLine("This action has been successfully discarded.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Can't recognise this command. Please try again.");
                        answer = Console.ReadLine();
                    }
                    
                } while (!(answer.ToUpper() == "Y" || answer.ToUpper() == "N"));
                
            }
        }

        public override void MagicCast(Wizard wizard, Character character)
        {
            if (_power > 0)
            {
                if (character.CurrentHealth >= _power)
                {
                    character.CurrentHealth -= _power;
                    _power = 0;
                    character.Condition = Conditions.Poisoned;
                }
                else
                {
                    _power -= character.CurrentHealth;
                    character.CurrentHealth = 0;
                    character.Condition = Conditions.Dead;
                }
            }
            else
            {
                Console.Error.WriteLine("This staff can't be used. This item's power is 0.");
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (_power > 0)
            {
                Console.Error.WriteLine("Warning! You are about to cast this spell on your hero." +
                                        " This will decrease your OWN hero's health. Type \"Y\" if you wish to proceed." +
                                        "Type \"N\" if you wish to discard this action.");
                string answer = Console.ReadLine();
                do
                {
                    if (answer.ToUpper() == "Y")
                    {
                        if (wizard.CurrentHealth >= _power)
                        {
                            wizard.CurrentHealth -= _power;
                            _power = 0;
                            wizard.Condition = Conditions.Poisoned;
                        }
                        else
                        {
                            _power -= wizard.CurrentHealth;
                            wizard.CurrentHealth = 0;
                            wizard.Condition = Conditions.Dead;
                        }
                    }
                    else if(answer.ToUpper() == "N")
                    {
                        Console.WriteLine("This action has been successfully discarded.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Can't recognise this command. Please try again.");
                        answer = Console.ReadLine();
                    }
                    
                } while (!(answer.ToUpper() == "Y" || answer.ToUpper() == "N"));
            }
        }
    }
}