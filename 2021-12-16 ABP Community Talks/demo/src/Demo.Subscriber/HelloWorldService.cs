using System;
using Volo.Abp.DependencyInjection;

namespace Demo.Subscriber
{
    public class HelloWorldService : ITransientDependency
    {
        public void SayHello()
        {
            Console.WriteLine("\tHello World!");
        }
    }
}
