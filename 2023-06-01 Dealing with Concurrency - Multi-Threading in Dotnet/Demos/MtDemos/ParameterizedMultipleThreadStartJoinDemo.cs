namespace MtDemos
{
    public static class ParameterizedMultipleThreadStartJoinDemo
    {
        public static void Run()
        {
            var thread1 = new Thread(new ParameterizedThreadStart(RunThread));
            var thread2 = new Thread(new ParameterizedThreadStart(RunThread));

            Logger.Log("Starting the threads...");
            thread1.Start(5);
            thread2.Start(8);
            
            Thread.Sleep(500);

            Logger.Log("Started the threads, waiting to stop...");
            thread1.Join();
            thread2.Join();

            Logger.Log("Threads stopped, exiting...");
        }

        private static void RunThread(object? arg)
        {
            var count = Convert.ToInt32(arg);
            for (int i = 1; i <= count; i++)
            {
                Logger.Log(i.ToString());
                Thread.Sleep(100);
            }
        }
    }
}
