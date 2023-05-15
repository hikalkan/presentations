namespace MtDemos
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //ThreadStartJoinDemo.Run();

            //MultipleThreadStartJoinDemo.Run();

            //ParameterizedMultipleThreadStartJoinDemo.Run();

            //SharingSimpleStateDemo.Run();
            //SharingSimpleStateDemo_Interlocked.Run();
            //SharingSimpleStateDemo_Lock.Run();
            //SharingSimpleStateDemo_Lock_Alternative.Run();

            //SharingSimpleStateDemo_Monitor.Run();

            //ProducerConsumerDemo.Run();

            //AsyncCodeDemo.Run();
            SemaphoreDemo.Run();
        }
    }
}