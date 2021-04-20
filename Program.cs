using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameKash.Artefacts;
using GameKash.Spells;
using GameKash.HeroTools;

namespace GameKash
{
    class Program
    {
        static void Main()
        {
            //Wizard Artas = new Wizard("Artas", Races.Human, Genders.Male, 30, 900, 400);
            Wizard Kenarius = new Wizard("Kenarius", Races.Elf, Genders.Male, 100000, 4000,
                40);
            Character Thunder = new Character("Thunder", Races.Orc, Genders.Male, 40, 2700);
            Kenarius.CurrentHealth = 850;



       
            // Artifacts can be picked up and dropped.
            Thunder.GetArtefact(new AquaVitae(AquaVitae.Volumes.Large));
 
            // Artifacts can be transferred, already zaebis:
            Thunder.GiveArtefact(Kenarius, new AquaVitae(AquaVitae.Volumes.Large));

            // Wizards can learn a spell
            Kenarius.LearnSpell(new AddHealth(false, false));
            // Cast
            Kenarius.MagicCast(new AddHealth(false, false), Thunder);
            // And forget it
            Kenarius.ForgetSpell(new AddHealth(false, false));
            

            Console.WriteLine(Kenarius.CurrentHealth);
            Console.WriteLine("********************");
            Console.WriteLine(Kenarius.CurrentMana);
            
            //AddHealth addHealth = new AddHealth(2, false, false);
            //addHealth.MagicCast(Kenarius, Thunder, 10);
            /*AquaVitae aquaVitae = new AquaVitae(AquaVitae.Volumes.Large);
            AquaVitae aquaVitae2 = new AquaVitae(AquaVitae.Volumes.Large);
            DeadWater deadWater = new DeadWater(DeadWater.Volumes.Small);
            deadWater.ArtefactCast(Kenarius);
            aquaVitae.ArtefactCast(Kenarius, Thunder);
            aquaVitae2.ArtefactCast(Kenarius, Thunder);*/
            LightningStaff lightningStaff = new LightningStaff(100);
            lightningStaff.MagicCast(Kenarius, 90);
            Console.WriteLine("----------------------------------------------");
            
            Console.WriteLine(Kenarius.CurrentHealth);
            Console.WriteLine("********************");
            Console.WriteLine(Kenarius.CurrentMana);

        }
    }
}
