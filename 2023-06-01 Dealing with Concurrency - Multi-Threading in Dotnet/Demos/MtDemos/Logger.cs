namespace MtDemos
{
    public static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"[T#{Thread.CurrentThread.ManagedThreadId:000}][{DateTime.Now:HH:mm:ss.fff}] {message}");
        }
    }
}
