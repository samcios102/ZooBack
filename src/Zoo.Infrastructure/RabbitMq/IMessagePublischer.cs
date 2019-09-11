using System.Threading.Tasks;

namespace Zoo.Infrastructure.RabbitMq
{
    public interface IMessagePublischer
    {
        Task PublishAsync<TMessage>(TMessage message) where TMessage : class;
    }
}