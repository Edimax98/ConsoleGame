using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class GameScene: BattleEventsHandler, PurchaseEventHandler
    {
        private Hero player;
        private string[] actionButtonsInfo = { "W - attack monster", "A - buy a weapon", "D - buy an armor", "S - heal", "Q - Exit" };
        private HashSet<ConsoleKey> actionButtons = new HashSet<ConsoleKey> { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D, ConsoleKey.Q };
        
        private void createHero()
        {
            this.player = new Hero(10, 100, 1, 100);
            this.player.battleEventsHandler = this;
            this.player.purchaseEventsHandler = this;
        }

        private void showPreparedMenu()
        {
            printMenuWith(actionButtonsInfo);
            handleSelectedAction(recivedInput());
        }

        private void showHeroInfo(Hero hero)
        {
            Console.Write($"Health = {hero.getHealth()} \n");
            Console.Write($"Max health = {hero.getMaxHealth()} \n");
            Console.Write($"Strength = {hero.getStrength()} \n");
            Console.Write($"Coins = {hero.getCoinsAmount()} \n");
        }

        public void startGame()
        {
            createHero();
            showPreparedMenu();
        }

        // Battle events handler methods
        public void hostileNpcDead(HostileNPC hostileNpc)
        {
            Console.Write($"You have killed a {hostileNpc.GetType()} \n");
            showPreparedMenu();
        }

        public void playableCharacterDead(Playable player)
        {
            Console.Write("You have been killed \n");
            showHeroInfo(this.player);
            Console.Write("NEW GAME. \n");
            startGame();
        }

        public void playableCharacterWasDefeatedBy(HostileNPC hostileNpc)
        {
            Console.Write("Defeat. \n");
            showHeroInfo(player);
            Console.Write("\n");
            showPreparedMenu();
        }

        // Purchase events handler methods
        public void notEnoughMoneyFor(Item item)
        {
            Console.Write($"You don't have enough money. Price - {item.price} coin(s) \n");
            Console.Write("\n");
            showPreparedMenu();
        }

        public void itemWasBought()
        {
            Console.Write("Purchase successful! \n");
            showHeroInfo(this.player);
            Console.Write("\n");
            showPreparedMenu();
        }

        public void couldNotBuy(string message)
        {
            Console.Write($"Could not buy item. {message} \n");
            showPreparedMenu();
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
                        player.attack(new Monster());
                        break;
                    }
                case ConsoleKey.S:
                    {
                        player.buy(new Potion());
                        break;
                    }
                case ConsoleKey.A:
                    {
                        player.buy(new Weapon());
                        break;
                    }
                case ConsoleKey.D:
                    {
                        player.buy(new Armor());
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
    }
}
