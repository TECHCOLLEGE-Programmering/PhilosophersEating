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

        public Philosopher(Fork LeftFork, Fork RightFork)
        {
            this.LeftFork = LeftFork;
            this.RightFork = RightFork;
        }
        public void EatAMeal()
        {
            while (true)
            {
                // If right fork is free
                if (RightFork.p == null)
                {
                    Say(Thread.CurrentThread.Name + " takes right fork");
                    RightFork.p = this;
                    // wait until left fork is free
                    Say(Thread.CurrentThread.Name + "Waits for left fork to become available");
                    do
                    { /* Wait for fork to become free */ }
                    while (LeftFork.p != null);
                    Say(Thread.CurrentThread.Name + " takes right left");
                    LeftFork.p = this;

                    // Sleep (eat) for 3 seconds
                    // Tråd skal sove i 3 sekunder
                    Say(Thread.CurrentThread.Name + " eats for 3 seconds");
                    Thread.Sleep(3000);

                    // let go of right fork
                    RightFork = null;
                    Say(Thread.CurrentThread.Name + " drops right fork");
                    // let go of left fork
                    LeftFork = null;
                    Say(Thread.CurrentThread.Name + " drops right fork");
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
