namespace MutexDemo
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            var mutex = new Mutex(false, "MutexDemo");

            if (!mutex.WaitOne(100))
            {
                Console.WriteLine("Another instance of the application is already running. Exited!");
                return -1;
            }

            Console.WriteLine("Application has started. Press <<ENTER>> to exit...");
            Console.ReadLine();
            
            mutex.ReleaseMutex();
            return 0;
        }
    }
}