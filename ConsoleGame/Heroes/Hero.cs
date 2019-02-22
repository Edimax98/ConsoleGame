using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public abstract class Hero
    {
        private Team team;
        public EventManager eventManager = new EventManager();
        public string Name { get; protected set; }
        public int BaseDamage { get; protected set; }

        public int Health 
        {
            get
            {
                return Health;
            }
            protected set
            {
                if (value <= 0)
                {
                }
            }
        }

        public int Damage 
        {
            get
            {
                return BaseDamage + CalculateDamageBonus();
            }
            private set 
            {
                Damage = value;
            } 
        }

        protected Hero(string name, int health, int damage, Team team) 
        {
            this.team = team;
            Name = name;
            Health = health;
            BaseDamage = damage;
        }

        public string GetInfo() 
        {
            return $"{Name} ({Health}), base damge: {Damage}";
        }

        public void DamageTakenBy(Hero hero)
        {
            Health -= hero.Damage;
        }

        public void Attack(Hero hero)
        {
            hero.DamageTakenBy(this);
        }

        public string GetTeamName()
        {
            return team.Name;
        }

        protected int CalculateDamageBonus()
        {
            int damageBonus;
            Random random = new Random();
            damageBonus = random.Next(20, 150);
            return damageBonus;
        }
    }
}
