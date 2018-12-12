using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Hero: Playable
    {
        public BattleEventsHandler battleEventsHandler;
        public PurchaseEventHandler purchaseEventsHandler;

        int health;
        int maxHealth;
        int strength;
        int coins;

        public Hero(int health, int maxHealth, int strength, int coins)
        {
            this.health = health;
            this.maxHealth = maxHealth;
            this.strength = strength;
            this.coins = coins;
        }

        // Access methods
        public int getStrength()
        {
            return this.strength;
        }

        public int getHealth()
        {
            return this.health;
        }

        public int getCoinsAmount()
        {
            return this.coins;
        }

        public int getMaxHealth()
        {
            return this.maxHealth;
        }

        private bool checkIfNeedHealing()
        {
            return this.health != this.maxHealth;
        }

        private void checkIfDeath()
        {
            if (this.health <= 0)
            {
               battleEventsHandler.playableCharacterDead(this);
           }
        }

        // Playable interface methods
        public void damageTaken(int damageAmount)
        {
            if (this.health - damageAmount <= 0)
            {
                battleEventsHandler.playableCharacterDead(this);
            } else
            {
                this.health -= damageAmount;
            }
        }

        public void buy(Item item)
        { 
            if (item.price > this.coins)
            {
                purchaseEventsHandler.notEnoughMoneyFor(item);
            } else
            {
                if (item is Armor)
                {
                    this.maxHealth += (item as Armor).calculateBuffPoints();
                }

                if (item is Weapon)
                {
                    this.strength += (item as Weapon).calculateBuffPoints();
                }

                if (item is Potion)
                {
                    if (checkIfNeedHealing() == false)
                    {
                        purchaseEventsHandler.couldNotBuy("You have full hp");
                        return;
                    }
                    var healGiven = (item as Potion).calculateBuffPoints();
                    int needToHeal = this.maxHealth - this.health;
                    if (healGiven < needToHeal)
                    {
                        this.health += healGiven;
                    }
                    else
                    {
                        this.health += this.maxHealth - this.health;
                    } 
                }
                this.coins -= item.price;
                purchaseEventsHandler.itemWasBought();
            }
        }

        public void attack(HostileNPC enemy)
        {
            if ((enemy is Monster) == false) { return; }

            var monster = enemy as Monster;

             double chance = monster.calculateChanceOfVictoryWith(this);

            if (chance >= 0.5) {
                this.coins += monster.reward;
                this.health -= monster.calculateDamageAfterLossBattleWith(this);
                checkIfDeath();
                battleEventsHandler.hostileNpcDead(monster);
            }
            else
            {
                this.health -= monster.damageAmountAfterVictory;
                checkIfDeath();
                //battleEventsHandler.playableCharacterWasDefeatedBy(monster);
            }
        }
    }
}
