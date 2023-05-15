namespace MtDemos
{
    public static class ThreadLocalDemo
    {
        private static ThreadLocal<int> _number = new ThreadLocal<int>();

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
        }

        private static void RunThread()
        {
            _number.Value = Thread.CurrentThread.ManagedThreadId;
            Logger.Log($"RunThread Thread Id = {_number.Value}");
            OtherMethod();
        }

        private static void OtherMethod()
        {
            Logger.Log($"OtherMethod Thread Id = {_number.Value}");
        }
    }
}
