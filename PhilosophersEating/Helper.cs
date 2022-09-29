using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilosophersEating
{
    internal class Helper
    {

        // lock object mutual exclusion in getForks method
        private static Object rootObject;

        private static Helper instance;  // Singleton instance

        private Helper()  // Singleton private constructor
        { }

        public static Helper getInstance() // getting singleton instance
        {
            if (instance == null)
            {
                rootObject = new object();
                instance = new Helper();
            }
            return instance;
        }

        public void getForks(Philosopher philosopher)
        {
            // If right fork is free
            lock (rootObject)
            {
                if (philosopher.RightFork.p == null)
                {
                    // Say(Name + " takes first fork");
                    philosopher.RightFork.p = philosopher;
                    // wait until left fork is free
                    Console.WriteLine(philosopher.Name + " Waits for second fork to become available");
                    do /* Wait for fork to become free */
                    {
                        Thread.Sleep(10);
                    }
                    while (philosopher.LeftFork.p != null);
                    // Say(Name + " takes right left");
                    philosopher.LeftFork.p = philosopher;
                }
            }
        }

    }
}
