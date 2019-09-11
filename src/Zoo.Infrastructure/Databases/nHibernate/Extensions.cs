using Microsoft.Extensions.DependencyInjection;

namespace Zoo.Infrastructure.Databases.nHibernate
{
    internal static class Extensions
    {
        public static void AddNHibernate(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<AppSessionFactory>();
            serviceCollection.AddTransient(sp => sp.GetService<AppSessionFactory>().OpenSession());
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(NHibernateRepository<>));
        }
    }
}