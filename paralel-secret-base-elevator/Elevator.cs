using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ParalelProgrammingExamProject
{
    class Elevator
    {
        private Semaphore semaphore;
        private static Dictionary<string, int> floors;
        private static int elevatorSpeed=1000;
        public int CFloor;

        public Elevator(int capacity = 1,int cFloor=0) //only [capacity] number of agents can enter elevator at a time 
        {
            semaphore = new Semaphore(capacity, capacity);
            floors = new Dictionary<string, int>();
            CFloor = cFloor;
        }
        public static int getElevatorSpeed()
        {
            return elevatorSpeed;
        }

        //add floors to dictionary
        public void floorsAdd()
        {
            floors.Add("G", 0);
            floors.Add("S", 1);
            floors.Add("T1", 2);
            floors.Add("T2", 3);
        }

        //return count of floors
        public int numberOfFloors()
        {
            return floors.Count();
        }
        
        //block other threads while one is inside
        public void EnterElevator()
        {
            semaphore.WaitOne();
        }

        //current thread done,release place for another 
        public void LeaveElevator()
        {
            semaphore.Release();
        } 

    }
}
