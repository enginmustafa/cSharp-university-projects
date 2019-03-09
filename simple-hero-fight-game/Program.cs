//Course assignment "Product inventory"
// Written by Engin Mustafa, SE-1
// Faculty №: 1701321011

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamGame.Heroes;

namespace ExamGame
{
    class Program
    {

        static void Main(string[] args)
        {
            Assassin a1 = new Assassin();
            Knight k1 = new Knight();
            Monk m1 = new Monk();
            Warrior w1 = new Warrior();
            Wizzard wi1 = new Wizzard();

            GameEngine.Fight(w1, wi1);
        }
    }
}
