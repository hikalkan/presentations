using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ECommerce.Ordering;

public interface IOrderAppService : IApplicationService
{
    Task CreateAsync(OrderCreationDto input);
}