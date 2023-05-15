namespace MtDemos
{
    public static class AsyncCodeDemo
    {
        public static void Run()
        {
            Logger.Log("Starting tasks...");

            var task1 = Task.Run(RunThreadAsync);
            var task2 = Task.Run(RunThreadAsync);

            Task.WaitAll(task1, task2);

            Logger.Log("Tasks stopped, exiting...");
        }

        public static async Task RunThreadAsync()
        {
            for (int i = 1; i <= 10; i++)
            {
                Logger.Log(i.ToString());
                await Task.Delay(100);
            }
        }
    }
}
