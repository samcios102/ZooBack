using Microsoft.Extensions.DependencyInjection;
using Zoo.Application.Commands;
using Zoo.Application.Events;

namespace Zoo.Application
{
    public static class Extensions
    {
        public static void RegisterApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddCommandHandlers();
            serviceCollection.AddEventHandlers();
        }
    }
}