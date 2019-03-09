using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame.Heroes
{

    //Abilities: 30% chance to completely block the attack;
    public class Monk : Hero
    {
        public Monk(double health = 700, double attack = 300, double armour=80) : base(health, attack, armour)
        {

        }

        //This hero has blocking ability.
        public override bool blockingAbility()
        {
            //30% chance to block the  attack, return true(block the attack) if random number is under or equal to 30
            int random = GameEngine.getRandomNumber();
            if (random <= 30)
            {
                return true;
            }
            else return false;
        }

    }
}
