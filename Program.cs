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

        static void NewChapter(int chapter, Character MainPerson, string incorrect_input_message) {
            Console.WriteLine();
            Console.WriteLine($"+++[Глава {chapter - 1} пройдена]+++");
            MainPerson.Experience = 15;
            Console.WriteLine("+++[Нажмите любую клавишу для перехода]+++");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"+++[Ваши характеристики]+++");
            Console.WriteLine(MainPerson);
            Console.WriteLine("+++[Ваш инвентарь]+++");
            Console.WriteLine(MainPerson.Inventory);
            
            Console.WriteLine("+++[Хотите ли вы применить артефакты/заклинания]+++");
            List<string> choses = MainPerson.Inventory.GetListOfInventory();
            choses.Add("No");
            string chose = ChoseSimulation(choses, incorrect_input_message);
            if (chose == "No") {
                return;
            }
            else {

            }
        }
        static string ChoseSimulation(List<string> choses, string incorrect_input_message) {
            string outs = "--[";
            for (int i = 0; i < choses.Count(); i++) {
                if(i != choses.Count() - 1)
                    outs += choses[i] + "|";
                else
                    outs += choses[i];
            }
            outs += "]--";

            Console.WriteLine(outs);
            string chose = Console.ReadLine();
            while(!choses.Contains(chose)) {
                Console.WriteLine(incorrect_input_message);
                chose = Console.ReadLine();
            }
            return chose;
        }
        static void Main()
        {
            string incorrect_input_message = "Некорректный ввод, введите ещё раз.";

            
            #region creating_main_character
            Console.WriteLine("Яркий солнечный свет, проникающий сквозь веки, помог мне прийти в себя.");
            Console.WriteLine("Открыв глаза, я осмотрелся. Итак, я нахожусь на небольшой лесной полянке.");

            Console.WriteLine("Потом осмотрел своё тело. --[А кто я?]--");
            string chose = ChoseSimulation(new List<string> { "Human", "Gnome", "Elf", "Orc", "Goblin" }, incorrect_input_message);
            Races race = Races.Human;
            switch(chose) {
                case "Human":
                    race = Races.Human;
                    break;
                case "Gnome":
                    race = Races.Gnome;
                    break;
                case "Elf":
                    race = Races.Elf;
                    break;
                case "Orc":
                    race = Races.Orc;
                    break;
                case "Goblin":
                    race = Races.Goblin;
                    break;
            }

            Console.WriteLine("--[А какого я пола?]--");
            chose = ChoseSimulation(new List<string> { "Male", "Female" }, incorrect_input_message);
            Genders gender = chose == "Male" ? Genders.Male : Genders.Female;

            Console.WriteLine("--[А я умею колдовать?]--");
            chose = ChoseSimulation(new List<string> { "Yes", "No" }, incorrect_input_message);
            bool isWizard = chose == "Yes" ? true : false;

            Console.WriteLine("--[А как меня зовут?]--");
            string name = Console.ReadLine();

            Character MainPerson;
            if(!isWizard) {
                MainPerson = new Character(name, race, gender, 20, 500.0);
            }
            else {
                MainPerson = new Wizard(name, race, gender, 40, 500.0, 300.0);
            }

            #endregion
            
            #region found_aqua_vitae
            Console.WriteLine("Вроде все мои знания оказались при мне. Похоже всё нормально.");
            Console.WriteLine("Размышляя о весьма важных для меня вещах, я заметил небольшую бутылку у моих ног.");
            Console.WriteLine("--[Подобрать бутылку]--");
            chose = ChoseSimulation(new List<string> { "Yes", "No" }, incorrect_input_message);
            if (chose == "Yes") {
                MainPerson.GetArtefact(new AquaVitae(AquaVitae.Volumes.Normal), false);
            }
            #endregion

            #region rider
            Console.WriteLine("Из-за поворота на тракте сначала показался передовой всадник на вороном коне.");
            Console.WriteLine("Одет он по военному - кольчуга, шлем, сапоги, на плечах линялый плащ, в ножнах меч, а в руке копьё с вымпелом.");
            Console.WriteLine("Всадник подскакал ко мне и остановил коня.");
            Character Rider = new Character("Rider", Races.Human, Genders.Male, 25, 100.0);
            Rider.Inventory.GetArtefact(new LightningStaff(200));
            Console.WriteLine("-Всадник: Кто такой, и куда направляешься?");    
            chose = ChoseSimulation(new List<string> { "Нагрубить", $"Я {name}" }, incorrect_input_message);
            if (chose == "Нагрубить") {
                Console.WriteLine($"-{name}: Чё тебе надо, думаешь крутой на коне?");
                Console.WriteLine("--[Всадник атаковал вас]--");
                MainPerson.CurrentHealth -= 50;

                while(MainPerson.Condition != Conditions.Dead && Rider.Condition != Conditions.Dead) {
                    Console.WriteLine("--[Что делать?]--");
                    chose = ChoseSimulation(new List<string> { "Атаковать", "Бежать" }, incorrect_input_message);
                    if(chose == "Атаковать") {
                        Rider.CurrentHealth -= 25;
                        Console.WriteLine("--[Всадник атаковал вас]--");
                        MainPerson.CurrentHealth -= 50;
                    }
                    if(chose == "Бежать") {
                        Console.WriteLine("-Всадник: Куда бежишь, я на коне!");
                        Console.WriteLine("--[Всадник догоняет вас и атакует]--");
                        MainPerson.CurrentHealth -= 35;
                    }
                }

                if (Rider.Condition == Conditions.Dead) {
                    Console.WriteLine("--[Вы убили всадника и забрали у него артефакт]--");
                    MainPerson.GetArtefact(new PoisonousSaliva(100), false);
                }
                else if (MainPerson.Condition == Conditions.Dead) {
                    Console.WriteLine("--[Вы умерли, игра окончена]--");
                    Environment.Exit(0);
                }
                
            }
            else {
                Console.WriteLine($"-{name}: Я {name} и иду я в Изенгард, где надеюсь найти службу.");
                Console.WriteLine("~Так я решил назваться в Средиземье, и имя это придумал сам.~");
                Console.WriteLine("-Мужчина спрыгнул на землю и подошел ко мне поближе, оказавшись ростом примерно метр восемьдесят.");
                Console.WriteLine("-Всадник: И что же ты здесь делаешь?");
                Console.WriteLine("~В этот момент я почувствовал общий настрой этого человека - смесь подозрительности, " +
                    "заинтересованности и досады на возможную задержку, связанною с тем, что придется разбираться со мной." +
                    " Но, самое главное, враждебность от него не исходила.~");
   
                chose = ChoseSimulation(new List<string> { "Я сам не знаю", "Я путешественник" }, incorrect_input_message);
                if (chose == "Я путешественник") {
                    Console.WriteLine("-Всадник: Интересно, и откуда ты?");
                    chose = ChoseSimulation(new List<string> { "Из Ендерма", "Из Изенгарда" }, incorrect_input_message);
                    if (chose == "Из Ендерма") {
                        Console.WriteLine("-Всадник: Моя семья родом оттуда, землякам нужно помогать. Держи.");
                        Rider.GiveArtefact(MainPerson, new LightningStaff(200));
                    }
                    else {
                        Console.WriteLine("-Всадник: Ну хорошо, ступай своей дорогой");
                    }
                }
                else {
                    Console.WriteLine("-Всадник: Звучит глупо! Ты наверное гробокопатель. Умри!");
                    Console.WriteLine("--[Пока вы говорили со всадником, к нему подбежали трое других]--");
                    Console.WriteLine("--[Вы пытались убежать, но что-то пошло не так]--");
                    Console.WriteLine("--[Вы умерли, игра окончена]--");
                    Environment.Exit(0);
                }
            }



            #endregion

            NewChapter(2, MainPerson, incorrect_input_message);

        }
    }
}
