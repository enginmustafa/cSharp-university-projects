using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame.Heroes
{

    //Abilities: 10% chance to make %200 damage; 20% chance to completely block the attack;
    public class Knight : Hero
    {
        public Knight(double health=600, double attack=200, double armour=50) : base(health, attack, armour)
        {

        }
        public override double getAttack()
        {
            int randomA = GameEngine.getRandomNumber();

            if (randomA <= 10) { return attack * 2; } //10% chance to make %200 damage
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
            //20% chance to block the  attack, return true(block the attack) if random number is under or equal to 20
            int random = GameEngine.getRandomNumber();
            if (random <= 20)
            {
                return true;
            }
            else return false;
        }

    }
}
