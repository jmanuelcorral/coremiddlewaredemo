using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Sample01
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class PrimeCheckerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly INumberChecker _checker;

        public PrimeCheckerMiddleware(RequestDelegate next, INumberChecker checker)
        {
            _next = next;
            _checker = checker;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.HasValue && httpContext.Request.Path.Value.Contains("primecheck"))
            {
                string value = httpContext.Request.Path.Value.Replace("/","").Replace("primecheck", "");
                int valuetocheck = (string.IsNullOrEmpty(value) || value == "0") ? 1 : Convert.ToInt32(value);
                if (_checker.CheckNumber(valuetocheck)) await httpContext.Response.WriteAsync("is prime");
                else await httpContext.Response.WriteAsync("is not prime");

            }
            else await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class PrimeCheckerMiddlewareExtensions
    {
        public static IApplicationBuilder UsePrimeCheckerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PrimeCheckerMiddleware>();
        }
    }
}
