using System;
using System.Linq;
using System.Security.Claims;
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
            using (TenantInfo.Change(FindTenant(httpContext)))
            {
                await _next(httpContext);
            }
        }

        private TenantInfo FindTenant(HttpContext httpContext)
        {
            var tenantId = FindFromClaims(httpContext) ??
                           FindFromDomain(httpContext) ??
                           FindFromHeader(httpContext) ??
                           FindFromCookie(httpContext);

            if (tenantId == null)
            {
                return null;
            }

            return new TenantInfo(Guid.Parse(tenantId));
        }

        private static string FindFromClaims(HttpContext httpContext)
        {
            return httpContext.User.FindFirstValue("_tenantId");
        }

        private string FindFromDomain(HttpContext httpContext)
        {
            return null;
        }

        private string FindFromHeader(HttpContext httpContext)
        {
            return httpContext.Request.Headers["_tenantId"].FirstOrDefault();
        }

        private string FindFromCookie(HttpContext httpContext)
        {
            return httpContext.Request.Cookies["_tenantId"];
        }
    }
}
