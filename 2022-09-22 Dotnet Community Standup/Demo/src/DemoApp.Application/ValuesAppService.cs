using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace DemoApp
{
    public class ValuesAppService : ApplicationService, IValuesAppService
    {
        private static int _value = 42;

        public async Task<int> GetAsync()
        {
            return _value;
        }

        [Authorize("CanIncreaseValue")]
        public Task IncreaseAsync()
        {
            if (_value == 50)
            {
                throw new UserFriendlyException("Can not increase more than 50, sorry :(");
            }
            
            _value++;
            return Task.CompletedTask;
        }
    }
}