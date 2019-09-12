using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Zoo.Infrastructure.Options
{
    internal static class Extensions
    {
        public static void AddOption<TOption>(this IServiceCollection services, string section)
            where TOption : class, new()
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var options = new TOption();

                configuration.GetSection(section).Bind(options);
                services.AddSingleton(options);

            }
        }
    }
}