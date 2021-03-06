using System;
using System.Reflection;
using System.Resources;
using System.Collections.Generic;
using GameKash.Artefacts;
using GameKash.Spells;

namespace GameKash.HeroTools {
    public class Inventory {
        
        private ResourceManager rm = new ResourceManager("GameKash.Resources", Assembly.GetExecutingAssembly());
        
        private int capacity_artefacts;
        private int capacity_spells;
        private Artefact[] inventoryArtefacts;
        private Spell[] inventorySpells;
        private bool [] emptyArtefactsPlaces;
        private bool [] emptySpellsPlaces;

        public Inventory(int CapacityArtefacts = 5, int CapacitySpells = 5) {
            this.capacity_artefacts = CapacityArtefacts;
            this.capacity_spells = CapacitySpells;
            this.inventoryArtefacts = new Artefact[capacity_spells];
            this.inventorySpells = new Spell[capacity_spells];
            this.emptyArtefactsPlaces = new bool[capacity_artefacts];
            this.emptySpellsPlaces = new bool[capacity_spells];
            for(int i = 0; i < this.emptyArtefactsPlaces.Length; i++) {
                this.emptyArtefactsPlaces[i] = true;
            }
            for(int i = 0; i < this.emptySpellsPlaces.Length; i++) {
                this.emptySpellsPlaces[i] = true;
            }
        }

        // For the correct operation of all find methods below.
        // We must overload the artifact comparison operator.

        // Shit happening, when we finding artefact.
        // I don't know why, but artefact in our inventory changing
        // every time, when we pass another argument
        public int findArtefactSlot(Artefact artefact) {
            for(int i = 0; i < this.capacity_artefacts; i++) {
                if(inventoryArtefacts[i].Equals(artefact)) {
                 
                    return i;
                }
            }
            return -1;
        }
        public int findSpellSlot(Spell spell) {
            for(int i = 0; i < this.capacity_spells; i++) {
                if(this.inventorySpells[i].Equals(spell)) {
                    return i;
                }
            }
            return -1;
        }
        private int findEmptySlot(bool [] temp) {
            for (int i = 0; i < temp.Length; i++) {
                if (temp[i] == true){
                    return i;
                }
            }
            return -1;
        }

        public void GetArtefact(Artefact artefact) {
            int emptySlot = findEmptySlot(emptyArtefactsPlaces);
            if (emptySlot == -1) {
                throw new Exception(rm.GetString("ArtefactsLimit"));
            }
            else {
                inventoryArtefacts[emptySlot] = artefact;
                emptyArtefactsPlaces[emptySlot] = false;
            }
        }
        public void DropArtefact(Artefact artefact) {
            int slot = findArtefactSlot(artefact);
            if(slot != -1) {
                emptyArtefactsPlaces[slot] = true;
                inventoryArtefacts[slot] = null;
            }

            else {
                throw new Exception("You don't have this artefact.");
            }
        }


        public void LearnSpell(Spell spell) {
            int emptySlot = findEmptySlot(emptyArtefactsPlaces);
            if (emptySlot == -1) {
                throw new Exception(rm.GetString("SpellsLimit"));
            }
            else {
                inventorySpells[emptySlot] = spell;
                emptySpellsPlaces[emptySlot] = false;
            }
        }

        public void ForgetSpell(Spell spell) {
            int slot = findSpellSlot(spell);
            if (slot != -1) {
                emptySpellsPlaces[slot] = true;
                inventorySpells[slot] = null;
            }
            else {
                throw new Exception(rm.GetString("NoSpell"));
            }         
        }

        public List <string> GetListOfInventory() {
            List<string> inventory = new List<string>();
            for(int i = 0; i < capacity_artefacts; i++) {
                if(this.inventoryArtefacts[i] != null)
                    inventory.Add(inventoryArtefacts[i].ToString());
            }
            for(int i = 0; i < capacity_spells; i++) {
                if(this.inventorySpells[i] != null)
                    inventory.Add(inventorySpells[i].ToString());
            }

            return inventory;
        }

        public override string ToString() {
            string artefacts = "";
            for (int i = 0; i < capacity_artefacts; i++) {
                if(this.inventoryArtefacts[i] != null)
                    artefacts += $"<{this.inventoryArtefacts[i].ToString()}> ";
            }
            string spells = "";
            for(int i = 0; i < capacity_spells; i++) {
                if(this.inventorySpells[i] != null)
                    spells += $"[{this.inventorySpells[i].ToString()}] ";
            }
            return $"--[Artefacts: {artefacts}]--\n--[Spells: {spells}]--\n";
        }

    }
}
