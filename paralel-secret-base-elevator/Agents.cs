using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParalelProgrammingExamProject
{
    class Agents
    {
        private static Random rand = new Random();

        private int elevatorSpeed = Elevator.getElevatorSpeed();

        public string Name { get; private set; }

        public static string[] securityLevels = new string[] { "Confidential", "Secret", "Top-Secret" };
        
        public string SecurityLevel { get; private set; }

        public int FloorOfAgent { get; private set; }

        public Elevator Elevator { get; private set; }

        //method to get random number, lock prevents getting repeatedly same number 
        public static int GetRandomValue(int boundary)
        {
            lock (rand) return rand.Next(boundary);
        }
        public Agents(string name, Elevator elevator,string securityLevel, int floorOfAgent)
        {
            Name = name;
            SecurityLevel = securityLevel;
            Elevator = elevator;
            FloorOfAgent = floorOfAgent;
        }

        //Choose randomly a floor
        private int chooseFloor()
        {

                int n = Elevator.numberOfFloors();
                int option = GetRandomValue(n);
                return option;
        }

        //Get a random security level
        public static string getSecurityLevel()
        {
            int level = GetRandomValue(securityLevels.Count()); //generate a number between array lenght
            return securityLevels[level]; //return a random security level
        }

        
        public void Go()
        {
            Elevator.EnterElevator();

            //variable to store chosen floor (through a method)
            int chosenFloor = chooseFloor();

            //true: agent chose the floor he is at 
            bool sameFloor = true;
            Console.WriteLine($"{Name} called the elevator.");

            //while elevator and agent aren't on the same floor, move the elevator
            while (FloorOfAgent != Elevator.CFloor) {
                Console.WriteLine($"{Name} is on {FloorOfAgent} floor while elevator is on {Elevator.CFloor} floor.");

                //if elevator is under agent: go up
                if (FloorOfAgent > Elevator.CFloor) {
                    Console.WriteLine("Elevator going up.");
                    Thread.Sleep(elevatorSpeed);
                    Elevator.CFloor++;
                    Console.WriteLine($"Elevator is on {Elevator.CFloor} floor.");
                }

                //if elevator is over agent: go down 
                else if (FloorOfAgent < Elevator.CFloor)
                {
                    Console.WriteLine("Elevator going down.");
                    Thread.Sleep(elevatorSpeed);
                    Elevator.CFloor--;
                    Console.WriteLine($"Elevator is on {Elevator.CFloor} floor.");
                }
            }

            //When agent and elevator are on the same floor
            Console.WriteLine($"{Name} got on elevator and chose {chosenFloor} floor, current floor: {Elevator.CFloor}.");

            ReCheck:
            //If agent chooses a lower floor
            if (chosenFloor > Elevator.CFloor)
            {
                sameFloor = false; //not sameFloor
                Console.WriteLine("Elevator going up.");
                Thread.Sleep(elevatorSpeed);
                Elevator.CFloor++;
                Console.WriteLine($"Elevator is on {Elevator.CFloor} floor.");
                goto ReCheck;
            }

            //If agent chooses an upper floor
            else if (chosenFloor < Elevator.CFloor)
            {
                sameFloor = false; //not sameFloor
                Console.WriteLine("Elevator going down.");
                Thread.Sleep(elevatorSpeed);
                Elevator.CFloor--;
                Console.WriteLine($"Elevator is on {Elevator.CFloor} floor.");
                goto ReCheck; }


            //if elevator is on the desired floor
            else if (chosenFloor==Elevator.CFloor)
                {
                
                //if agent chooses the same floor he is at, leave elevator
                if (sameFloor) { Console.WriteLine($"{Name} choose the same floor he is at and left the elevator.");
                    Elevator.LeaveElevator();
                }

                else { 
                Console.WriteLine($"Checking whether {Name} has needed security level for {Elevator.CFloor} floor.");

                    /*check whether particular agent is allowed at the exact floor, 
                      if so, leave elevator, else: choose another floor */
                    switch (Elevator.CFloor)
                    {
                        case 0:
                            if (SecurityLevel.Equals("Confidential")
                            || SecurityLevel.Equals("Secret")
                            || SecurityLevel.Equals("Top-Secret"))
                            {
                                Console.WriteLine($"{Name} left elevator on {Elevator.CFloor} floor.");
                                Elevator.LeaveElevator();
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"{Name} doesn't have security level needed for {Elevator.CFloor} floor.");
                                chosenFloor = chooseFloor();
                                Console.WriteLine($"{Name} chose to go to {chosenFloor} floor.");
                                goto ReCheck;
                            }

                        case 1:
                            if (SecurityLevel.Equals("Secret")
                            || SecurityLevel.Equals("Top-Secret"))
                            {
                                Console.WriteLine($"{Name} left elevator on {Elevator.CFloor} floor.");
                                Elevator.LeaveElevator();
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"{Name} doesn't have security level needed for {Elevator.CFloor} floor.");
                                chosenFloor = chooseFloor();
                                Console.WriteLine($"{Name} chose to go to {chosenFloor} floor.");
                                goto ReCheck;
                            }
                        case 2: case 3:
                            if (SecurityLevel.Equals("Top-Secret"))
                            {
                                Console.WriteLine($"{Name} left elevator on {Elevator.CFloor} floor.");
                                Elevator.LeaveElevator();
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"{Name} doesn't have security level needed for {Elevator.CFloor} floor.");
                                chosenFloor = chooseFloor();
                                Console.WriteLine($"{Name} chose to go to {chosenFloor} floor.");
                                goto ReCheck;
                            }
                        default:
                            throw new ArgumentOutOfRangeException("Invalid floor: " + Elevator.CFloor.ToString());
                    }
                }

                }
            else Console.WriteLine("Something unexpected happened.");


        }

    }
}
