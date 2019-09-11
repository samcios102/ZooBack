using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Application.Events;
using Zoo.Application.Queries;

namespace Zoo.Infrastructure.Queries
{
    internal static class Extensions
    {
        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromCallingAssembly()
                    .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }
        
    }
}