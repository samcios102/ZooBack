using Microsoft.Extensions.DependencyInjection;
using Zoo.Application.Commands;
using Zoo.Application.Events;
using Zoo.Application.Queries;

namespace Zoo.Infrastructure.Dispatchers
{
    internal static class Extensions
    {
        public static void AddDispatchers(this IServiceCollection services)
        {
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IEventDispatcher, EventDispatcher>();
        }
    }
}