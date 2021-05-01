using System;
using System.Reflection;
using System.Resources;
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
        ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());
        
        public Inventory Inventory;
        private static int NextId { get; set; }
        public int Id { get; }
        public string Name { get; }
        public Conditions Condition { get; set; } = Conditions.Normal;
        public bool AbilityToTalk { get; set; } = true;
        public bool AbilityToMove { get; set; } = true;
        public Races Race { get; }
        public Genders Gender { get; }
        private int _age;
        public int Age
        { 
            get
            { 
                return _age;
            } 
            set
            {
                if (value < _age || value < 0)
                    throw new Exception(rm.GetString("InvalidAge"));
                _age = value;
            }
        }
        private double _currentHealth;
        public double CurrentHealth
        {
            get
            {
                return _currentHealth;
            }
            set
            {
                if(value > MaxHealth)
                    throw new Exception(rm.GetString("InvalidHealth"));
                else if(value < 0)
                    _currentHealth = 0;
                else
                    _currentHealth = value;
                this.Status();
                Console.WriteLine($"--[Здоровье {this.Name}: {_currentHealth}]--");
            }
        }
        public double MaxHealth { get; }
        private int _experience;
        public int Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (value < _experience)
                    throw new Exception(rm.GetString("InvalidAge"));
                _experience = value;
            }
        }

        public Character(string name, Races race, Genders gender, int age, double maxHealth, int experience = 0)
        {
            if (String.IsNullOrEmpty(name) || name.Contains('\0'))
                throw new Exception(rm.GetString("InvalidName"));
            if(age < 0)
                throw new Exception(rm.GetString("InvalidAge"));
            if(maxHealth <= 0)
                throw new Exception(rm.GetString("InvalidHealth"));
            Inventory = new Inventory();
            Id = ++NextId;
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
                throw new Exception("Error.");
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
                   $"ID: {Id}\n" +
                   $"Condition: {Condition}\n" +
                   $"Race: {Race}\n" +
                   $"Gender: {Gender}\n" + 
                   $"Age: {Age}\n" +
                   $"Max Health: {MaxHealth}\n" +
                   $"Current Health: {CurrentHealth}\n" +
                   $"Experience: {Experience}\n";
        }
        
        public void GetArtefact(Artefact artefact) {
            this.Inventory.GetArtefact(artefact);
        }

        public void DropArtefact(Artefact artefact) {
            this.Inventory.DropArtefact(artefact);
        }

        public void GiveArtefact(Character character, Artefact artefact) {
            this.Inventory.DropArtefact(artefact);
            character.Inventory.GetArtefact(artefact);
            Console.WriteLine($"--[Персонаж {this.Name} передал артефакт {artefact.GetType().Name} персонажу {character.Name}]--");
        }
    }
}