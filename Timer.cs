using System;
using System.Threading;

namespace GetXmlFiles
{
    class InitializeTimer
    {
        private readonly JobProcessor _jobProcessor = new JobProcessor();
        public void Timer()
        {
            var callback = new TimerCallback(_jobProcessor.Process);
            Console.WriteLine("Creating timer: {0}\n",
                            DateTime.Now.ToString("h:mm:ss"));

            // create a one second timer tick
            Timer stateTimer = new Timer(callback, null, 0, 5000);

            // loop here forever
            for (; ; )
            {
                // add a sleep for 100 mSec to reduce CPU usage
                Thread.Sleep(100);
            }
        }
    }
}
