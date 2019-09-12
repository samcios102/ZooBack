using Microsoft.Extensions.DependencyInjection;
using Zoo.Core.Repositories;

namespace Zoo.Infrastructure.Repositories
{
    internal static class Extensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAnimalRepository, AnimalRepository>();
        }
    }
}