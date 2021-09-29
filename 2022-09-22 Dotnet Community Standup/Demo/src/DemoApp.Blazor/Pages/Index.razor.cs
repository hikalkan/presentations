using System.Threading.Tasks;

namespace DemoApp.Blazor.Pages
{
    public partial class Index
    {
        private int Value { get; set; }
        
        private readonly IValuesAppService _valuesAppService;

        public Index(IValuesAppService valuesAppService)
        {
            _valuesAppService = valuesAppService;
        }

        protected override async Task OnInitializedAsync()
        {
            Value = await _valuesAppService.GetAsync();
        }
        
        private async Task IncreaseAsync()
        {
            if (await Message.Confirm("Are you sure to increase it?"))
            {
                await _valuesAppService.IncreaseAsync();
                Value = await _valuesAppService.GetAsync();

                await Notify.Success("Increased it, yeah :)");
            }
        }
    }
}
