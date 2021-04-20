using System;
using System.Reflection;
using System.Resources;


namespace GameKash
{
    public class Wizard : Character
    {
        ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());
        
        public double MaxMana { get; }
        private double _currentMana;
        public double CurrentMana
        {
            get
            {
                return _currentMana;
            }
            set
            {
                if (value > MaxMana || value < 0)
                    throw new Exception(rm.GetString("InvalidMana"));
                _currentMana = value;
            }
        }
        public Wizard(string name, Races race, Genders gender, int age, double maxHealth, double maxMana, int experience = 0) 
            :base(name, race, gender, age, maxHealth, experience)
        {
            if (maxMana <= 0)
                throw new Exception(rm.GetString("InvalidMana"));
            MaxMana = maxMana;
            CurrentMana = maxMana;
        }
        public override string ToString()
        {
            return base.ToString() +
                   $"Max Mana: {MaxMana}\n" +
                   $"Current Mana: {CurrentMana}\n";
        }

        public void LearnSpell(Spell spell) {
            inventory.LearnSpell(spell);
        }
        public void ForgetSpell(Spell spell) {
            inventory.ForgetSpell(spell);
        }

    }
}
