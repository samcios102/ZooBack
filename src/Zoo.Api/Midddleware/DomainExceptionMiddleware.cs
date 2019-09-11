using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Zoo.Core.Exceptions;

namespace Zoo.Api.Midddleware
{
    public class DomainExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public DomainExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException exception)
            {
                context.Response.StatusCode = 400;

                var result = exception.Message;
                var json = JsonConvert.SerializeObject(result);

                await context.Response.WriteAsync(json);
            }
        }
    }
}