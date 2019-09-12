using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Zoo.Infrastructure.Options;

namespace Zoo.Infrastructure.RabbitMq
{
    internal static class Extensions
    {
        public static void AddRabbitMq(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddOption<RabbitMqOptions>("rabbitMq");
            serviceCollection.AddSingleton(sp =>
            {
                var options = sp.GetService<RabbitMqOptions>();

                var factory = new ConnectionFactory
                {
                    HostName = options.HostName,
                    VirtualHost = options.VirtualHost,
                    UserName = options.Username,
                    Password = options.Password
                };

                return factory.CreateConnection();
            });

            serviceCollection.AddSingleton<IMessagePublischer, MessagePublischer>();
            serviceCollection.AddSingleton<IMessageSubscriber, MessageSubscriber>();
        }
    }
}