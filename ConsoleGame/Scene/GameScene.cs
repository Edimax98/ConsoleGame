using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class GameScene: BattleEventsHandler
    {
        private PlayableTeam playersTeam = new PlayableTeam();
        private AiTeam aiTeam = new AiTeam();
        
        private void AddHeroesToTeams()
        {
            aiTeam.Heroes.Add(new Knight());
            aiTeam.Heroes.Add(new Elf());
            aiTeam.Heroes.Add(new Wizard());

            playersTeam.Heroes.Add(new Knight());
            playersTeam.Heroes.Add(new Elf());
            playersTeam.Heroes.Add(new Wizard());
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
            foreach(IHero hero in playersTeam.Heroes)
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

        private IHero FindHeroBy(int index, ITeam team)
        {
            int i = 0;
            foreach (IHero hero in team.Heroes)
            {
                i++;
                if (index == i)
                {
                    return hero;
                }
            }
            return null;
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
            IHero foundPlayerHero = FindHeroBy(InputHeroNumberToAttack(), playersTeam);
            Console.Write("Choose enemy hero to attack: ");
            IHero foundAiHero = FindHeroBy(InputHeroNumberToAttack(), aiTeam);
            foundPlayerHero.Attack(foundAiHero);
        }

        public void StartGame()
        {
            InputPlayerTeamName();
            ShowGeneratedAiTeamName();
            PauseGame();
            AddHeroesToTeams();
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

        string FindTeamNameFor(IHero hero)
        {
            if (aiTeam.Heroes.Contains(hero))
            {
                return $"({aiTeam.Name})";
            }
            return $"({playersTeam.Name})";
        }

        // Battle events handling
        public void HeroHasBeenKilled(IHero victim, IHero killer)
        {
            Console.Write($"{killer.Name} killed {victim.Name}\n");
        }

        public void HeroHasBeenHurt(IHero victim, IHero attackingHero)
        {
            Console.Write($"{attackingHero.Name} {FindTeamNameFor(attackingHero)} made {attackingHero.Damage} damage to {victim.Name} {FindTeamNameFor(victim)}\n");
        }
    }
}
