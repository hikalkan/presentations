using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ECommerce.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<CustomerDto> GetAsync(Guid id);
    }
}
