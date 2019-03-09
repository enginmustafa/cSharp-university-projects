using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame.Heroes
{
    public abstract class Hero
    {
        public double health { get; set; }
        public double attack { get; set; }
        public double armour { get; set; }

        public Hero(double health, double attack, double armour)
        {
            this.health = health;
            this.attack = attack;
            this.armour = armour;
        }

        //calculate randomly attack points (80% to %120)
        public virtual double getAttack() {
            int random = GameEngine.getRandomNumber();
            if (random < 20) { return attack * 80 / 100; }
            else if (random > 20 && 40 > random) { return attack * 90 / 100; }
            else if (random > 40 && 60 > random) { return attack; }
            else if (random > 60 && 80 > random) { return attack * 110 / 100; }
            else return attack * 120 / 100;
        }

        //calculate randomly health points (add from %80 to %120 armour points)
        public virtual double getHealth() {
            int random = GameEngine.getRandomNumber();
            if (random < 20) { return health + armour * 80 / 100; }
            else if (random > 20 && 40 > random) { return health + armour * 90 / 100; }
            else if (random > 40 && 60 > random) { return health + armour; }
            else if (random > 60 && 80 > random) { return health + armour * 110 / 100; }
            else return health + armour * 120 / 100;
        } 

        //method to check whether a hero has blocking ability
        public virtual bool blockingAbility()
        {
            return false;
        }
        
    }
}
