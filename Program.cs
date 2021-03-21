using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKash
{
    class Program
    {
        static void Main()
        {
            Wizard Artas = new Wizard("Artas", Races.Human, Genders.Male, 30, 900, 400);
            Wizard Kenarius = new Wizard("Kenarius", Races.Elf, Genders.Male, 100000, 4000, 1500);
            Character Thunder = new Character("Thunder", Races.Orc, Genders.Male, 40, 2700);
            Artas.CurrentHealth = 850;
            Artas.Status();
            //Console.WriteLine(Artas + "\n");
            Kenarius.AddHealth(Artas);
            Console.WriteLine(Kenarius + "\n");
            Artas.Status();
            Console.WriteLine(Artas);
        }
    }
}
