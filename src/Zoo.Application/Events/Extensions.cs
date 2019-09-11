using Microsoft.Extensions.DependencyInjection;

namespace Zoo.Application.Events
{
    internal static class Extensions
    {
        public static void AddEventHandlers(this IServiceCollection services)
        {
            services.Scan(scan =>
                {
                    scan.FromAssemblyOf<IEvent>()
                        .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime();
                }
            );
        }
    }
}