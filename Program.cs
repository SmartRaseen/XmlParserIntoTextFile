using System;

namespace GetXmlFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var jobProcessor = new JobProcessor();
            var _timer = new InitializeTimer();
            _timer.Timer();
         // jobProcessor.Process(StateInfo);

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
