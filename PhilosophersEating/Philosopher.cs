using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhilosophersEating
{
    internal class Philosopher
    {
        Fork LeftFork;
        Fork RightFork;
        string Name;

        public Philosopher(Fork LeftFork, Fork RightFork, string Name)
        {
            this.LeftFork = LeftFork;
            this.RightFork = RightFork;
            this.Name = Name;
        }
        public void EatAMeal()
        {
            while (true)
            {
                // If right fork is free
                if (RightFork.p == null)
                {
                    // Say(Name + " takes first fork");
                    RightFork.p = this;
                    // wait until left fork is free
                    Say(Name + " Waits for second fork to become available");
                    do
                    { /* Wait for fork to become free */ }
                    while (LeftFork.p != null);
                    // Say(Name + " takes right left");
                    LeftFork.p = this;

                    // Sleep (eat) for 3 seconds
                    // Tråd skal sove i 3 sekunder
                    // Say(Name + " eats for 0.2 seconds");
                    Thread.Sleep(10);

                    // let go of right fork
                    RightFork.p = null;
                    // Say(Name + " drops right fork");
                    // let go of left fork
                    LeftFork.p = null;
                    // Say(Name + " drops left fork");
                    // Sleep (digest) 3 seconds
                    // Tråd skal sove i 3 sekunder
                    // Say(Thread.CurrentThread.Name + " eats for 3 seconds");
                    // Thread.Sleep(3000);
                }
            }
        }

        private void Say(String s)
        {
            Console.WriteLine(s);
        }

    }
}
