using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class GameScene: IEventListener
    {
        private PlayableTeam playersTeam = new PlayableTeam("fefe", new List<Hero>());
        private AiTeam aiTeam = new AiTeam("fefe",new List<Hero>());


        private void AssembleTeams()
        {
            List<Hero> playerHeroes = new List<Hero> { new Elf("Mighty elf",1000,100, playersTeam), new Knight("Stupid knight",500,170, playersTeam) };
            List<Hero> aiHeroes = new List<Hero> { new Elf("Green elf", 1000, 100, playersTeam), new Knight("Brave knight", 500, 170, playersTeam) };
        }

        private void InputPlayerTeamName()
        {   
           Console.Write("Input team name: ");
           playersTeam.Name = Console.ReadLine();
        }

        private void ShowGeneratedAiTeamName()
        {
            Console.Write($"Ai chose team name: {aiTeam.Name}");
        }

        private void PrintTeamHeroesInfo()
        {
            int i = 0;
            Console.Write("------------------------------\n");
            foreach(Hero hero in playersTeam.Heroes)
            {
                Console.Write($"{i}. {hero.GetInfo()}\n");
            }
            Console.Write("==============================\n");
        }

        private void PrintAiTeamInfo()
        {
            Console.Write(aiTeam.Name);
            Console.Write("\n");
            PrintTeamHeroesInfo();
        }

        private void PrintPlayerTeamInfo() 
        {
            Console.Write(playersTeam.Name);
            Console.Write("\n");
            PrintTeamHeroesInfo();
        }

        private void PauseGame() 
        {
            ConsoleKeyInfo cki;
            Console.Write("\n");
            Console.Write("------\n");
            do
            {
                Console.Write("To continue press Enter...");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Enter);
        }

        private void StartBattle()
        {
            Console.Write("Choose hero for attack: ");
            //IHero foundPlayerHero = FindHeroBy(InputHeroNumberToAttack(), playersTeam);
            Console.Write("Choose enemy hero to attack: ");
            //IHero foundAiHero = FindHeroBy(InputHeroNumberToAttack(), aiTeam);
            //foundPlayerHero.Attack(foundAiHero);
        }

        public void StartGame()
        {
            InputPlayerTeamName();
            ShowGeneratedAiTeamName();
            PauseGame();
            AssembleTeams();
            PrintPlayerTeamInfo();
            PrintAiTeamInfo();
            StartBattle();
        }

        private int InputHeroNumberToAttack()
        {
            int number = 0;
            try
            {
               number = System.Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Write("Wrong input"); 
            }
            catch (OverflowException)
            {
                Console.Write("Too big value"); 
            }
            return number;
        }

        public void HeroHasBeenKilled(Hero attacker, Hero victim)
        {

        }

        public void HeroHasBeenHurt(Hero attacker, Hero victim)
        {

        }
    }
}
