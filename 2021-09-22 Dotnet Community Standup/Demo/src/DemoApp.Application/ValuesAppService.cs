using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;

namespace DemoApp
{
    //[DisableAuditing]
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
            if (_value >= 50)
            {
                throw new UserFriendlyException("Can not be higher than 50");
            }
            
            _value++;
            return Task.CompletedTask;
        }
    }
/*
    [DisableAuditing]
    public class PersonalInfoDto
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
    */
}