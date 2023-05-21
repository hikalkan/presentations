namespace MtDemos
{
    public static class SharingSimpleStateDemo_Lock_Alternative
    {
        private static int _counter = 0;
        private static object _syncObj = new();

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

            Logger.Log("Threads stopped, exiting...");
            Logger.Log("Counter: " + _counter.ToString("0,000,000"));
        }

        private static void RunThread()
        {
            lock (_syncObj)
            {
                for (int i = 1; i <= 1_000_000; i++)
                {
                    _counter++;
                }
            }
        }
    }
}
