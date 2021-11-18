using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DemoApp
{
    public interface IValuesAppService : IApplicationService
    {
        Task<int> GetAsync();
        Task IncreaseAsync();
    }
}