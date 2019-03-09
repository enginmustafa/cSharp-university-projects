using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamGame.Heroes;

namespace ExamGame
{
    public class GameEngine
    {
        //get random number from 1-100
        public static int getRandomNumber() {
            Random rnd = new Random();
            return rnd.Next(1, 100); 
        }

        public static void Fight(Hero one, Hero two) {
            Console.WriteLine("First hero - Health:{0}, Attack:{1}, Armour:{2};",one.health,one.attack,one.armour);
            Console.WriteLine("Second hero - Health:{0}, Attack:{1}, Armour:{2};",two.health,two.attack, two.armour);

            double attack1,attack2,health1,health2;
            one.getHealth();
            two.getHealth();
            

            //fight while health of the two heroes > 0
            while (one.health > 0 && two.health > 0)
            {
                attack1 = one.getAttack();
                attack2 = two.getAttack();
                health1 = one.getHealth();
                health2 = two.getHealth();

                //Receive no damage
                if (two.blockingAbility())
                {
                    Console.WriteLine("Health two: {0}", two.health);
                }

                //No blocking ability,receive damage
                else
                {
                    //if health of second hero is less than or equal to 0, make it equal to 0(for further use*) and exit the fight
                    if (two.health - attack1 <= 0) { two.health = 0; break; }
                    two.health = health2 - attack1;
                    Console.WriteLine("Health two: {0}", two.health);
                }

                //Receive no damage
                if (one.blockingAbility())
                {
                    Console.WriteLine("Health two: {0}", two.health);
                }

                //No blocking ability,receive damage
                else
                {
                    //if health of first hero is less than or equal to 0, make it equal to 0(for further use*) and exit the fight
                    if (one.health - attack2 <= 0) { one.health = 0; break; }
                    one.health = health1 - attack2;
                    Console.WriteLine("Health one: {0}", one.health);
                }
            } 

            //* if health of hero one=0, he is dead;
            if (one.health==0) Console.WriteLine("Hero one: Dead");
            //else, the other one is dead;
            else Console.WriteLine("Hero two: Dead");
            Console.ReadKey();

        }
    }
}
