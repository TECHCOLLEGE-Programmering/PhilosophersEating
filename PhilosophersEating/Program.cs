using PhilosophersEating;
using System;

namespace MyApp
{
    internal class Program
    {
        private static string[] PhilosopherNames = { "Wittgenstein", "Nietzsche", "Platon", "Aristoteles", "Decartes" };
        Thread[] threads = new Thread[5];

        private Philosopher[] philosophers = new Philosopher[5];
        private Fork[] forks = new Fork[5];
        public void go()
        {
            // Instantier 5 gafler
            for (int i = 0; i < 5; i++)
              forks[i] = new Fork();

            // Instantier 5 filosoffer med hver to gafler (højre og venstre)
            philosophers[0] = new Philosopher(forks[0], forks[1], PhilosopherNames[0]);
            philosophers[1] = new Philosopher(forks[1], forks[2], PhilosopherNames[1]);
            philosophers[2] = new Philosopher(forks[2], forks[3], PhilosopherNames[2]);
            philosophers[3] = new Philosopher(forks[3], forks[4], PhilosopherNames[3]);
            philosophers[4] = new Philosopher(forks[4], forks[0], PhilosopherNames[4]);

            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(new ThreadStart(philosophers[i].EatAMeal));
                threads[i].Name = PhilosopherNames[i];
            }

            for (int i = 0; i < 5; i++)
            {
                threads[i].Start();
                Thread.Sleep(200);
            }
            // Start filosoffernes tråde
            do { } while (!Console.KeyAvailable);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.go();
            // new Program().go();
        }
    }
}