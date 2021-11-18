using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Demo.Publisher
{
    public class PublisherService : ITransientDependency
    {
        public async Task RunAsync()
        {
            Console.WriteLine("\tHello World!");
        }
    }
}
