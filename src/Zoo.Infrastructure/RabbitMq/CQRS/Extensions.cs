using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Application.Events;

namespace Zoo.Infrastructure.RabbitMq.CQRS
{
    internal static class Extensions
    {
        public static void SubscribeEvent<TEvent>(this IMessageSubscriber subscriber)
            where TEvent : class, IEvent
        {
            subscriber.Subscribe<TEvent>(async (sp, @event) =>
            {
                var dispatcher = sp.GetService<IEventDispatcher>();
                await dispatcher.DispatchAsync(@event);
            });
        }

        public static Task PublishEventAsync<TEvent>(this IMessagePublischer publischer, TEvent @event)
            where TEvent : class, IEvent
        {
           return publischer.PublishAsync(@event);
        }
    }
}