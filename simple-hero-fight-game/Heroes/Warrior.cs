using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamGame;

namespace ExamGame.Heroes
{

    //Abilities: No abilities;
    public class Warrior : Hero
    {
        public Warrior(double health = 1000, double attack = 100, double armour = 99) : base(health, attack, armour)
        {
        }
        
    }
}
