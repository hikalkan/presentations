namespace MtDemos
{
    public static class MultipleThreadStartJoinDemo
    {
        public static void Run()
        {
            var thread1 = new Thread(RunThread);
            var thread2 = new Thread(RunThread);

            Logger.Log("Starting the threads...");
            thread1.Start();
            thread2.Start();
            
            Thread.Sleep(500);

            Logger.Log("Started the threads, waiting to stop...");
            thread1.Join();
            thread2.Join();

            Logger.Log("Thread stopped, exiting...");
        }

        public static void RunThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Logger.Log(i.ToString());
                Thread.Sleep(100);
            }
        }
    }
}
