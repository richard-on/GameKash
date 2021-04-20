using System;
using System.Reflection;
using System.Resources;
using GameKash.Spells;
using GameKash.Artefacts;

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

        public void MagicCast(Spell spell, Character character) {
            int ind = inventory.findSpellSlot(spell);
            if(ind != -1) {
                Console.WriteLine("Character {0} cast a spell {1} on {2}", this.Name, spell.GetType().Name, character.Name);
                spell.MagicCast(this, character);
            }
            else {
                throw new Exception("This wizard don't know this spell");
            }
        }
        public void MagicCast(Spell spell) {
            int ind = inventory.findSpellSlot(spell);
            if (ind != -1) {
                Console.WriteLine("Character {0} cast a spell {1} on {2}", this.Name, spell.GetType().Name, this.Name);
                spell.MagicCast(this);
            }
            else {
                throw new Exception("This wizard don't know this spell");
            }
        }

        public void UseArtifact(Artefact artefact, Character character) {
            int ind = inventory.findArtefactSlot(artefact);
            if(ind != -1) {
                Console.WriteLine("Character {0} cast a spell {1} on {2}", this.Name, artefact.GetType().Name, character.Name);
                artefact.MagicCast(this, character);
                if(!artefact._isRenewable) {
                    inventory.DropArtefact(artefact);
                }
            }
            else {
                throw new Exception("This character doesn't have this artifact");
            }
        }
        public void UseArtifact(Artefact artefact) {
            int ind = inventory.findArtefactSlot(artefact);
            if(ind != -1) {
                Console.WriteLine("Character {0} cast a spell {1} on {2}", this.Name, artefact.GetType().Name, this.Name);
                artefact.MagicCast(this);
                if(!artefact._isRenewable) {
                    inventory.DropArtefact(artefact);
                }
            }
            else {
                throw new Exception("This character doesn't have this artifact");
            }
        }



    }
}
