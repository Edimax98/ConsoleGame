using System;
namespace ConsoleGame
{
    public class Elf : IHero
    {
        BattleEventsHandler battleEventsHandler = null;
        private IHero attackingHero = null;
        private int health = 500;
        public int Health 
        { 
            get 
            {
                return health;
            }
            set 
            {
                if (value <= 0) 
                {
                    battleEventsHandler.HeroHasBeenKilled(this, attackingHero);
                }
                else
                {
                    health = value;
                }
            }
        }

        public string Name 
        {
            get 
            {
                return "Wise elf";
            }
        }

        public int BaseDamage  
        {
            get 
            {
                return 70;
            }
        }

        public int Damage 
        {
            get 
            {
                return BaseDamage + CalculateDamageBonus();
            }
        }

        public int CalculateDamageBonus()
        {
            int damageBonus;
            Random random = new Random();
            damageBonus = random.Next(20, 150);
            return damageBonus;
        }

        public void DamageTakenBy(IHero hero)
        {
            Health -= hero.Damage;
            attackingHero = hero;
        }

        public void Attack(IHero hero)
        {
            hero.DamageTakenBy(this);
        }

        public string GetInfo()
        {
            return $"{Name} ({Health}), base damge: {Damage}";
        }
    }
}
