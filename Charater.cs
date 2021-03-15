using System;
using System.Collections.Generic;
using System.Text;

namespace GameKash
{
    class Character
    {



        private int Id { get; }
        private string Name { get; }
        private enum state { normal, weak, sick, poisoned, paralyzed, dead };
        public bool isAbleToTalk { get; private set; }
        public bool isAbleToMove { get; private set; }
        private enum race { human, gnome, elf, orc, goblin };
        private enum gender { man, woman };
        private int age { get; }
        public int health { get; private set; }
        public int maxHelth { get; private set; }
        public int experience { get; private set; }
    }
}
