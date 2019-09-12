using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Application.Events.Animals;
using Zoo.Application.Services;
using Zoo.Infrastructure.Databases;
using Zoo.Infrastructure.Dispatchers;
using Zoo.Infrastructure.Queries;
using Zoo.Infrastructure.RabbitMq;
using Zoo.Infrastructure.RabbitMq.CQRS;
using Zoo.Infrastructure.Repositories;

namespace Zoo.Infrastructure
{
    public static class Extensions
    {
        public static void RegisterInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddRabbitMq();
            serviceCollection.AddQueryHandlers();
            serviceCollection.AddDatabase();
            serviceCollection.AddDispatchers();
            serviceCollection.AddRepositories();
            serviceCollection.AddTransient<IMessageBroker, IMessageBroker>();
        }

        public static void UseInfrastructure(this IApplicationBuilder applicationBuilder)
        {
            var subscriber = applicationBuilder.ApplicationServices.GetService<IMessageSubscriber>();
            
            subscriber.SubscribeEvent<AnimalCreated>();
            subscriber.SubscribeEvent<AnimalDeleted>();
            subscriber.SubscribeEvent<AnimalUpdated>();
        }
    }
}