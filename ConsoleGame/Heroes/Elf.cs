using System;
namespace ConsoleGame
{
    public class Elf : IHero
    {
        public int Health 
        { 
            get 
            {
                return 60;
            }
            set 
            {
                if (value <= 0) 
                {
                    Console.Write($"{Name} is dead\n");
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
    }
}
