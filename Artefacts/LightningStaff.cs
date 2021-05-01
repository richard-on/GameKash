using System;
using System.Reflection;
using System.Resources;
using GameKash.Spells;

namespace GameKash.Artefacts
{
    public class LightningStaff : Artefact, IPower
    {
        private static ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());

        private const bool IsRenewable = true;
        private static double _power;

        public LightningStaff(double power) : base(power, IsRenewable)
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
                Console.Error.WriteLine($"This staff hasn't got enough power to proceed. Available power is {_power}." +
                                        $" Specified power is {power}.");
                return false;
            }

            return true;
        }

        public void MagicCast(Wizard wizard, Character character, double power)
        {
            if (IsValidInput(power))
            {
                if (character.CurrentHealth > power)
                {
                    character.CurrentHealth -= power;
                    _power -= power;
                }
                else
                {
                    character.CurrentHealth = 0;
                    character.Status();
                    _power = power - character.CurrentHealth;
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
                        if (wizard.CurrentHealth > power)
                        {
                            wizard.CurrentHealth -= power;
                            _power -= power;
                        }
                        else
                        {
                            wizard.CurrentHealth = 0;
                            wizard.Status();
                            _power = power - wizard.CurrentHealth;
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
                if (character.CurrentHealth > _power)
                {
                    character.CurrentHealth -= _power;
                    _power = 0;
                }
                else
                {
                    _power -= character.CurrentHealth;
                    character.CurrentHealth = 0;
                    character.Status();
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
                        if (wizard.CurrentHealth > _power)
                        {
                            wizard.CurrentHealth -= _power;
                            _power = 0;
                        }
                        else
                        {
                            _power -= wizard.CurrentHealth;
                            wizard.CurrentHealth = 0;
                            wizard.Status();
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
    }
}