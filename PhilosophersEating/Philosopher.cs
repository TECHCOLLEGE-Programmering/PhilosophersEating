using MyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static MyApp.Program;

namespace PhilosophersEating
{
    internal class Philosopher
    {
        public Fork LeftFork;
        public Fork RightFork;
        public string Name;

        Random random;
        ForkProviderMethod GetBothForks;

        public Philosopher(ForkProviderMethod ForkProvider, Fork LeftFork, Fork RightFork, string Name)
        {
            this.LeftFork = LeftFork;
            this.RightFork = RightFork;
            this.Name = Name;
            this.GetBothForks = ForkProvider;
            random = new Random();
        }
        public void EatAMeal()
        {
                Say(Name + " Attempting to take two forks");
                GetBothForks(this);

                // Tråd skal sove; svarer til at filosoffen spiser et stykke tid
                Thread.Sleep(random.Next(30)+10);

                // Finished eating, letting go of both forks
                LeftFork.p = null;
                RightFork.p = null;
                Say(Name + " dropped both forks");
        }

        private void Say(String s)
        {
            Console.WriteLine(s);
        }

    }
}
