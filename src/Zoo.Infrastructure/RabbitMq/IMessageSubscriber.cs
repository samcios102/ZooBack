using System;
using System.Threading.Tasks;

namespace Zoo.Infrastructure.RabbitMq
{
    public interface IMessageSubscriber
    {
        void Subscribe<TMessage>(Func<IServiceProvider, TMessage, Task> onReceived) where TMessage : class;
    }
}