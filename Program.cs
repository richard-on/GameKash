using System;
using System.Globalization;
using System.Threading;
using GameKash.Artefacts;
using GameKash.Spells;

namespace GameKash
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");

            try
            {
                Wizard wiz1 = new Wizard("Wiz1", Races.Elf, Genders.Male, 100, 10, 100);
                Wizard wiz2 = new Wizard("Wiz2", Races.Gnome, Genders.Female, 99, 20, 200);

                Character character1 = new Character("Character1", Races.Orc, Genders.Male, 40, 10);
                Character character2 = new Character("Character2", Races.Human, Genders.Female, 30, 25);

                AddHealth addHealth = new AddHealth(true, true);
                character1.CurrentHealth = 0;
                
                Console.WriteLine(wiz1.CurrentMana);
                Console.WriteLine(character1.CurrentHealth);
                addHealth.MagicCast(wiz1, character1);
                Console.WriteLine(wiz1.CurrentMana);
                Console.WriteLine(character1.CurrentHealth);

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }
    }
}
