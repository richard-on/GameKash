using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleGame
{
    enum Conditions { Normal, Weakened, Sick, Poisoned, Paralyzed, Dead }
    enum Races { Human, Gnome, Elf, Orc, Goblin }
    enum Genders { Male, Female }
    class Character : IComparable
    {
        private static int Next_ID { get; set; } = 0;
        public int ID { get; }
        public string Name { get; }
        public Conditions Condition { get; set; } = Conditions.Normal;
        public bool AbilityToTalk { get; set; } = true;
        public bool AbilityToMove { get; set; } = true;
        public Races Race { get; }
        public Genders Gender { get; }
        private int age;
        public int Age
        { 
            get
            { 
                return age;
            } 
            set
            {
                if (value < age)
                    throw new Exception("Invalid Age value");
                age = value;
            }
        }
        private double current_health;
        public double CurrentHealth
        {
            get
            {
                return current_health;
            }
            set
            {
                if (value > MaxHealth || value < 0)
                    throw new Exception("Invalid Health value");
                current_health = value;
            }
        }
        public double MaxHealth { get; }
        private int experience = 0;
        public int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                if (value < experience)
                    throw new Exception("Invalid Age value");
                experience = value;
            }
        }

        public Character(string name, Races race, Genders gender, int age, double max_health)
        {
            if (name == null || name.Contains('\0'))
                throw new Exception("Invalid Name value");
            if(age < 0)
                throw new Exception("Invalid Age value");
            if(max_health <= 0)
                throw new Exception("Invalid Health value");
            ID = ++Next_ID;
            Name = name;
            Race = race;
            Gender = gender;
            Age = age;
            MaxHealth = max_health;
            CurrentHealth = MaxHealth;
        }
        public int CompareTo(object o)
        {
            Character character = o as Character;
            if (character == null)
                throw new Exception("Error");
            return this.Experience.CompareTo(character.Experience);
        }
        public void Status()
        {
            if (CurrentHealth / MaxHealth < 0.1 && Condition == Conditions.Normal)
                Condition = Conditions.Weakened;
            else if (CurrentHealth / MaxHealth >= 0.1 && Condition == Conditions.Weakened)
                Condition = Conditions.Normal;
            if (CurrentHealth == 0)
                Condition = Conditions.Dead;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"ID: {ID}\n" +
                   $"Condition: {Condition}\n" +
                   $"Race: {Race}\n" +
                   $"Gender: {Gender}\n" + 
                   $"Age: {Age}\n" +
                   $"Max Health: {MaxHealth}\n" +
                   $"Current Health: {CurrentHealth}\n" +
                   $"Experience: {Experience}";
        }
    }
}