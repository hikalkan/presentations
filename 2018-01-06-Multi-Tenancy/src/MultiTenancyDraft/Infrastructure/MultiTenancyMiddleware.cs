using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MultiTenancyDraft.Infrastructure
{
    public class MultiTenancyMiddleware
    {
        private readonly RequestDelegate _next;

        public MultiTenancyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            TenantInfo.Current = new TenantInfo(Guid.NewGuid(), "acme");
            try
            {
                await _next(httpContext);
            }
            finally
            {
                TenantInfo.Current = null;
            }
        }
    }
}
