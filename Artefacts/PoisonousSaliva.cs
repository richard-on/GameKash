using System;
using System.Reflection;
using System.Resources;
using GameKash.Spells;

namespace GameKash.Artefacts
{
    public class PoisonousSaliva : Artefact, IPower
    {
        private static ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());
        
        private const bool IsRenewable = true;
        private double _power;

        public double Power { get { return _power; } }

        public PoisonousSaliva(double power) : base(power, IsRenewable)
        {
            if (power < 0)
            {
                throw new ArgumentException(rm.GetString("InvalidPowerValue"));
            }
            _power = power;
        }
        
        private bool IsValidInput(double power)
        {
            if (power < 0)
            {
                throw new ArgumentException(rm.GetString("InvalidPowerValue"));
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
                Console.Error.WriteLine(rm.GetString("SelfDamageWarning"));
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
                        Console.WriteLine(rm.GetString("ActionDiscarded"));
                        return;
                    }
                    else
                    {
                        Console.WriteLine(rm.GetString("InvalidUserCmd"));
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
                Console.Error.WriteLine(rm.GetString("NullItemPower"));
            }
        }

        public override void MagicCast(Wizard wizard)
        {
            if (_power > 0)
            {
                Console.Error.WriteLine(rm.GetString("SelfDamageWarning"));
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
                        Console.WriteLine(rm.GetString("ActionDiscarded"));
                        return;
                    }
                    else
                    {
                        Console.WriteLine(rm.GetString("InvalidUserCmd"));
                        answer = Console.ReadLine();
                    }
                    
                } while (!(answer.ToUpper() == "Y" || answer.ToUpper() == "N"));
            }
        }

        public override string ToString() {
            return $"{this.GetType().Name} {this.Power}";
        }

        public override bool Equals(Object obj) {
            if((obj as PoisonousSaliva).ToString().Equals(this.ToString()))
                return true;
            else
                return false;
        }
    }
}