namespace MtDemos
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ParameterizedMultipleThreadStartJoinDemo.Run();

            //SharingSimpleStateDemo.Run();
            //SharingSimpleStateDemo_Interlocked.Run();
            //SharingSimpleStateDemo_Lock.Run();

            //ProducerConsumerDemo.Run();
        }
    }
}