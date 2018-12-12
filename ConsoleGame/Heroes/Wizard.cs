using System;
namespace ConsoleGame
{
    public class Wizard: IHero
    {

        public int Health 
        {
            get 
            {
                return 100;
            }
            set
            {
                if (value <= 0)
                {
                    Console.Write($"{this.GetType()} is dead\n");
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
