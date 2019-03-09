using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParalelProgrammingExamProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Elevator elevator = new Elevator();
            elevator.floorsAdd();
            List<Agents> agents = new List<Agents>();
            
            //generate agents and add them to list of agents
            for (int i = 1; i < 3; i++)
            {
                //Add [i] agents (Name,Security level, the floor they are at)
                agents.Add(new Agents(i.ToString(), elevator,Agents.getSecurityLevel(),Agents.GetRandomValue(elevator.numberOfFloors())));
            }

            List<Thread> agentThreads = new List<Thread>();

            //Run all threads
            foreach (var a in agents)
            {
                Thread t = new Thread(a.Go);
                t.Start();
                agentThreads.Add(t);
            }
            foreach (var t in agentThreads)
            {
                t.Join();
            }

            Console.WriteLine("Simulation complete.");
            Console.ReadLine();

        }
    }
}
