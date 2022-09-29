using PhilosophersEating;
using System;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace MyApp
{
    internal class Program
    {
        private static string[] PhilosopherNames = { "Wittgenstein", "Nietzsche", "Platon", "Aristoteles", "Decartes" };
        Thread[] threads = new Thread[5];

        public delegate void ForkProviderMethod(Philosopher philosopher);
        ForkProviderMethod ForkProvider;
        Helper MyHelper;

        public Program()
        {
            MyHelper = Helper.getInstance();
            ForkProvider = MyHelper.getForks;
        }

        private Philosopher[] philosophers = new Philosopher[5];
        private Fork[] forks = new Fork[5];
        public void go()
        {
            // Instantier 5 gafler
            for (int i = 0; i < 5; i++)
              forks[i] = new Fork();

            // Instantier 5 filosoffer med hver to gafler (højre og venstre bordet rundt)
            philosophers[0] = new Philosopher(ForkProvider, forks[0], forks[1], PhilosopherNames[0]);
            philosophers[1] = new Philosopher(ForkProvider, forks[1], forks[2], PhilosopherNames[1]);
            philosophers[2] = new Philosopher(ForkProvider, forks[2], forks[3], PhilosopherNames[2]);
            philosophers[3] = new Philosopher(ForkProvider, forks[3], forks[4], PhilosopherNames[3]);
            philosophers[4] = new Philosopher(ForkProvider, forks[4], forks[0], PhilosopherNames[4]);

            // Instantier 5 tråde med filosoffernes EatMeal metode som den der kører i tråden
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(new ThreadStart(philosophers[i].EatAMeal));
                threads[i].Name = PhilosopherNames[i];
            }

            // Start alle 5 tråde
            for (int i = 0; i < 5; i++)
            {
                threads[i].Start();
                Thread.Sleep(300);
            }

            // Sørg for at main tråden ikke exit'er
            do { } while (!Console.KeyAvailable);
        }

            static void Main(string[] args)
        {
            new Program().go();
        }
    }
}