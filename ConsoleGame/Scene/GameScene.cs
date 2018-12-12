using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class GameScene: BattleEventsHandler, PurchaseEventHandler
    {
        private PlayableTeam playersTeam = new PlayableTeam();
        private AiTeam aiTeam = new AiTeam();

        private string[] actionButtonsInfo = { "W - attack monster", "A - buy a weapon", "D - buy an armor", "S - heal", "Q - Exit" };
        private HashSet<ConsoleKey> actionButtons = new HashSet<ConsoleKey> { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D, ConsoleKey.Q };
        
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

        // Menu actions handling
        private ConsoleKey recivedInput()
        {
            ConsoleKey key = new ConsoleKey();
            do
            {
                var cki = Console.ReadKey(true);
                key = cki.Key;
                if (!actionButtons.Contains(key))
                    Console.Write("Wrong button pressed. Try again.\n");
            } while (!actionButtons.Contains(key));
            return key;
        }

        private void handleSelectedAction(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    {
                        //player.attack(new Monster());
                        break;
                    } 
                case ConsoleKey.S:
                    {
                        //player.buy(new Potion());
                        break;
                    }
                case ConsoleKey.A:
                    {
                        //player.buy(new Weapon());
                        break;
                    }
                case ConsoleKey.D:
                    {
                        //player.buy(new Armor());
                        break;
                    }
            }
        }

        private void printMenuWith(string[] menuItems)
        {
            foreach(string item in menuItems)
            {
                Console.Write($"{item} \n");
            }
        }

        public void HeroHasBeenKilled(IHero hero)
        {

        }
    }
}
