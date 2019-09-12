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
        private readonly IMessagePublischer _publischer;

        public MessageBroker(IMessagePublischer publischer)
        {
            _publischer = publischer;
        }

        public async Task PublishAsync(params IEvent[] events)
        {
            var tasks = events.Select(e => _publischer.PublishEventAsync(e));
            await Task.WhenAll(tasks);
        }
    }
}