using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameKash.Artefacts;
using GameKash.HeroTools;

namespace GameKash
{
    public enum Conditions { Normal, Weakened, Sick, Poisoned, Paralyzed, Dead }
    public enum Races { Human, Gnome, Elf, Orc, Goblin }
    public enum Genders { Male, Female }
    public class Character : IComparable
    {
        public Inventory inventory;
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
                if (value < age || value < 0)
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

        public Character(string name, Races race, Genders gender, int age, double maxHealth, int experience = 0)
        {
            if (name == null || name.Contains('\0'))
                throw new Exception("Invalid Name value");
            if(age < 0)
                throw new Exception("Invalid Age value");
            if(maxHealth <= 0)
                throw new Exception("Invalid Health value");
            inventory = new Inventory();
            ID = ++Next_ID;
            Name = name;
            Race = race;
            Gender = gender;
            Age = age;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            Experience = experience;
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
        
        public void GetArtefact(Artefact artefact) {
            this.inventory.GetArtefact(artefact);
        }

        public void GiveArtefact(Character character, Artefact artefact) {
            this.inventory.DropArtefact(artefact);
            character.inventory.GetArtefact(artefact);
        }
    }
}