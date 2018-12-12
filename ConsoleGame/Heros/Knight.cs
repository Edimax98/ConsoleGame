using System;
namespace ConsoleGame
{
    public class Knight : Hero
    {
        public int Health 
        {
            get 
            {
                return 110;
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
                return "Brave knight";
            }
        }

        public int BaseDamage 
        {
            get 
            {
                return 45;
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
            damageBonus = random.Next(20, 50);
            return damageBonus;
        }
    }
}
