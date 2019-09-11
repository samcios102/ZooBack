using Microsoft.Extensions.DependencyInjection;

namespace Zoo.Application.Commands
{
    internal static class Extensions
    {
        public static void AddCommandHandlers(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromAssemblyOf<ICommand>()
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }
    }
}