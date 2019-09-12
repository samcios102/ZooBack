using System.Threading.Tasks;
using Zoo.Application.Events;

namespace Zoo.Application.Services
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IEvent[] events);
    }
}