using PhilosophersEating;
using System;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace MyApp
{
    internal class Program
    {
        private static string[] PhilosopherNames = { "Wittgenstein", "Nietzsche", "Platon", "Aristoteles", "Decartes" };
        // programmets størrelse afhænger af at længende af PhilosopherNames.
        Thread[] threads = new Thread[PhilosopherNames.Length];
        private Philosopher[] philosophers = new Philosopher[PhilosopherNames.Length];
        private Fork[] forks = new Fork[PhilosopherNames.Length];

        public delegate void ForkProviderMethod(Philosopher philosopher);
        ForkProviderMethod ForkProvider;
        Helper MyHelper;

        public Program()
        {
            MyHelper = Helper.getInstance();
            ForkProvider = MyHelper.getForks;
        }

        public void go()
        {
            // Instantier 5 gafler
            for (int i = 0; i < PhilosopherNames.Length; i++)
              forks[i] = new Fork();

            for(int i = 0; i < PhilosopherNames.Length; i++)
            {
                // Instantier 5 filosoffer med hver to gafler (højre og venstre bordet rundt)
                philosophers[i] = new Philosopher(ForkProvider, forks[i], forks[(i+1) % 5], PhilosopherNames[i]);
                // Instantier 5 tråde med filosoffernes EatMeal metode som den der kører i tråden
                threads[i] = new Thread(new ThreadStart(philosophers[i].EatAMeal));
                threads[i].Name = PhilosopherNames[i];
            }

            // Start alle tråde
            foreach (Thread t in threads)
            {
                t.Start();
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