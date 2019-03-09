using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame.Heroes
{

    //Abilities: 30% chancce to make %300 damage;
    public class Assassin : Hero
    {
        public Assassin(double health=750, double attack=150, double armour=70) : base(health,attack,armour)
        {

        }
        public override double getAttack()
        {
            int randomA = GameEngine.getRandomNumber();

            if (randomA <= 30) {return attack * 3;} //30% chance to make %300 damage
            else
            {
                int random = GameEngine.getRandomNumber();
                if (random < 2) { return attack * 80 / 100; }
                else if (random > 2 && 4 > random) { return attack * 90 / 100; }
                else if (random > 4 && 6 > random) { return attack; }
                else if (random > 6 && 8 > random) { return attack * 110 / 100; }
                else return attack * 120 / 100;
            }
        }
    }
}
