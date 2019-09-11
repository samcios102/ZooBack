using System.Threading.Tasks;

namespace Zoo.Application.Events
{
    public interface IEventDispatcher
    {
        Task DispatchAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}