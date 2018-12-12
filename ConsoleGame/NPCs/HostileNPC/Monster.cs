using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConsoleGame
//{
//    class Monster : HostileNPC
//    {
//        public int damageAmountAfterVictory
//        {
//            get
//            {
//                return 40;
//            }
//        }

//        public int reward
//        {
//            get
//            {
//                return 5;
//            }
//        }

//        public string getInfo()
//        {
//            return $"Damage if monster wins - {damageAmountAfterVictory} hp;";
//        }

//        public double calculateChanceOfVictoryWith(Hero hero)
//        {
//            double chance;
//            double firstPart = Math.Round((double)(hero.getStrength() * 7) / 100, 3);
//            double secondPart = 0.7;

//            chance = Math.Min(firstPart, secondPart);
//            return chance;
//        }

//        public int calculateDamageAfterLossBattleWith(Hero hero) {
//            return hero.getHealth() / 10;
//        }
//    }
//}
