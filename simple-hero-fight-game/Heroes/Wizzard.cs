using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamGame;

namespace ExamGame.Heroes
{

    //Abilities: 50% chance to make %200 damage; 5% chance to completely block the attack;
    class Wizzard : Hero
    {
        public Wizzard(double health = 250, double attack = 400, double armour = 20) : base(health, attack, armour)
        {
        }
        public override double getAttack()
        {
            int randomA = GameEngine.getRandomNumber();

            if (randomA <= 50) { return attack * 2; } //50% chance to make %200 damage
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

        //This hero has blocking ability.
        public override bool blockingAbility()
        {
            //5% chance to block the  attack, return true(block the attack) if random number is under or equal to 5 
            int random = GameEngine.getRandomNumber();
            if (random <= 5)
            {
                return true;
            }
            else return false;
        }

    }
}
