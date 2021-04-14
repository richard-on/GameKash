using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKash
{
    public class Wizard : Character
    {
        public double MaxMana { get; }
        private double current_mana;
        public double CurrentMana
        {
            get
            {
                return current_mana;
            }
            set
            {
                if (value > MaxMana || value < 0)
                    throw new Exception("Invalid Mana value");
                current_mana = value;
            }
        }
        public Wizard(string name, Races race, Genders gender, int age, double maxHealth, double maxMana, int experience = 0) 
            :base(name, race, gender, age, maxHealth, experience)
        {
            if (maxMana <= 0)
                throw new Exception("Invalid Mana value");
            MaxMana = maxMana;
            CurrentMana = maxMana;
        }
        public override string ToString()
        {
            return base.ToString() +
                   $"\nMax Mana: {MaxMana}\n" +
                   $"Current Mana: {CurrentMana}";
        }
        public void AddHealth(Character character)
        {
            if (CurrentMana / 2 > character.MaxHealth - character.CurrentHealth)
            {
                CurrentMana -= (character.MaxHealth - character.CurrentHealth) * 2;
                character.CurrentHealth = character.MaxHealth;
            }
            else
            {
                character.CurrentHealth += CurrentMana / 2;
                CurrentMana = 0;
            }
        }
    }
}
