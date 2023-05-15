namespace MtDemos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ThreadStartJoinDemo.Run();
            //MultipleThreadStartJoinDemo.Run();
            //ParameterizedMultipleThreadStartJoinDemo.Run();
            SharingSimpleStateDemo.Run();
            SharingSimpleStateDemo_Interlocked.Run();
        }
    }
}