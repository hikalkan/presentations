namespace MtDemos
{
    public static class ThreadStartStopDemo
    {
        public static void Run()
        {
            var thread = new Thread(RunThread);

            Logger.Log("Starting a new thread");
            thread.Start();
            
            Thread.Sleep(500);

            Logger.Log("Started the thread, waiting to stop");            
            thread.Join();

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
