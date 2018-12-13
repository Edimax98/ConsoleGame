using System;
namespace ConsoleGame
{
    public class Wizard: IHero
    {
        BattleEventsHandler battleEventsHandler = null;
        IHero attackingHero = null;
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
                return "Great wizard";
            }
        }

        public int BaseDamage 
        {
            get 
            {
                return 40;
            }
        }

        public int Damage 
        {
            get 
            {
                return BaseDamage + CalculateDamageBonus();
            }
        }

        public void Attack(IHero hero)
        {
            hero.DamageTakenBy(this);
            attackingHero = hero;
        }

        public int CalculateDamageBonus()
        {
            int damageBonus;
            Random random = new Random();
            damageBonus = random.Next(20, 50);
            return damageBonus;
        }

        public void DamageTakenBy(IHero hero)
        {
            Health -= hero.Damage;
        }

        public string GetInfo()
        {
            return $"{Name} ({Health}), base damge: {Damage}";
        }
    }
}
