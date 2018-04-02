using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace DotnetCoreDays.Filters
{
    public class AuditFilter : IAsyncActionFilter
    {
        private readonly ILogger<AuditFilter> _logger;

        public AuditFilter(ILogger<AuditFilter> logger)
        {
            _logger = logger;
        }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                return next();
            }
            finally
            {
                sw.Stop();

                _logger.LogInformation($"Executed {context.HttpContext.Request.Path} in {sw.Elapsed.TotalMilliseconds:0.00} ms.");
                _logger.LogInformation($"Action: {context.ActionDescriptor.DisplayName}, Controller: {context.Controller?.GetType()?.Name}");
            }
        }
    }
}
