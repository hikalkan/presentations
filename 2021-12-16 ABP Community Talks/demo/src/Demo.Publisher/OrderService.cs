using Demo.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Uow;

namespace Demo.Publisher
{
    public class OrderService : ITransientDependency
    {
        private readonly IDistributedEventBus _distributedEventBus;
        private readonly IRepository<Order, Guid> _orderRepository;
        private readonly ProductService _productService;

        public OrderService(
            IDistributedEventBus distributedEventBus,
            IRepository<Order, Guid> orderRepository,
            ProductService productService)
        {
            _distributedEventBus = distributedEventBus;
            _orderRepository = orderRepository;
            _productService = productService;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                try
                {
                    if (!await PlaceOrderAsync())
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            };
        }

        [UnitOfWork]
        protected virtual async Task<bool> PlaceOrderAsync()
        {
            Console.WriteLine();
            Console.WriteLine("*** PLACE A NEW ORDER ***");
            Console.WriteLine();

            Console.Write("Enter product code : ");
            var productCode = Console.ReadLine();
            if (productCode.IsNullOrWhiteSpace())
            {
                return false;
            }

            Console.Write("Enter amount       : ");
            var amount = int.Parse(Console.ReadLine());

            var productInfo = await _productService.GetAsync(productCode);

            var order = new Order
            {
                ProductCode = productCode,
                Amount = amount,
                TotalPrice = productInfo.Price * amount
            };

            await _orderRepository.InsertAsync(order);

            await _distributedEventBus.PublishAsync(
                new OrderPlacedEto
                {
                    ProductName = productInfo.Name,
                    ProductCode = order.ProductCode,
                    Amount = order.Amount,
                    TotalPrice = order.TotalPrice
                }
                //,onUnitOfWorkComplete: false //enable this line to immediately publish the event
                );

            if (order.Amount > 5)
            {
                /* Simulating an error occurred after the event is published,
                 * but before the transaction commited */ 
                throw new Exception("Can not place order with more than 5 products!");
            }

            return true;
        }
    }
}
