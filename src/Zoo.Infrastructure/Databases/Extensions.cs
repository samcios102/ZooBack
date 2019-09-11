using Microsoft.Extensions.DependencyInjection;
using Zoo.Infrastructure.Databases.nHibernate;
using Zoo.Infrastructure.Options;

namespace Zoo.Infrastructure.Databases
{
    internal static class Extensions
    {
        public static void AddDatabase(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddOption<DatabaseOptions>("Database");
            serviceCollection.AddNHibernate();
        }
    }
}