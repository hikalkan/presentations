namespace MtDemos
{
    public static class SharingSimpleStateDemo
    {
        private static int _counter = 0;

        public static void Run()
        {
            var thread1 = new Thread(RunThread);
            var thread2 = new Thread(RunThread);

            Logger.Log("Starting the threads...");
            thread1.Start();
            thread2.Start();

            Logger.Log("Started the threads, waiting to stop...");
            thread1.Join();
            thread2.Join();

            Logger.Log("Thread stopped, exiting...");
            Logger.Log("Counter: " + _counter.ToString("0,000,000"));
        }

        public static void RunThread()
        {
            for (int i = 1; i <= 1_000_000; i++)
            {
                _counter++;
            }
        }
    }
}
