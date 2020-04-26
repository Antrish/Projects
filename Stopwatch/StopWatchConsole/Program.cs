using System;
using System.Diagnostics;

namespace StopWatchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide inputs 'START' or 'STOP'");
            Stopwatch timer = new Stopwatch();
            String startTimer= Console.ReadLine();
            string stopTimer;
       
            if (startTimer.ToLower() =="start") 
            {
                timer.Start();
                Console.WriteLine("Timer Started ..., Type 'STOP' to stop timer.");
                
                Console.WriteLine("{0:hh\\:mm\\:ss}", timer.Elapsed);
                stopTimer = Console.ReadLine();
                if (stopTimer.ToLower() == "stop")
                {
                    timer.Stop();
                }
           }
            Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}", timer.Elapsed);
            Console.Read();
        }
    }
}
