using System.Linq;
using System.Threading.Tasks;
using Zoo.Application.Events;
using Zoo.Application.Services;
using Zoo.Infrastructure.RabbitMq;
using Zoo.Infrastructure.RabbitMq.CQRS;

namespace Zoo.Infrastructure.Services
{
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly IMessagePublischer _publisher;

        public MessageBroker(IMessagePublischer publisher)
        {
            _publisher = publisher;
        }

        public async Task PublishAsync(params IEvent[] events)
        {
            var tasks = events.Select(e => _publisher.PublishEventAsync(e));
            await Task.WhenAll(tasks);
        }
    }
}