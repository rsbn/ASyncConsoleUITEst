using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();
            worker.DoWork();
            while (!worker.Finished)
            {
                Console.Write("z");
                Thread.Sleep(100);
            }
            Console.WriteLine("\nFinished!");
            Console.ReadLine();
        }
    }

    public class Worker
    {
        public bool Finished { get; set; } = false;
        public async void DoWork()
        {
            Console.WriteLine("Starting");
            await TakeSomeRest();
            Finished = true;
        }

        private Task TakeSomeRest()
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Sleeping ...");
                Thread.Sleep(4000);
            });
        }
    }
}
