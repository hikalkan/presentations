using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ECommerce.Customers.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
