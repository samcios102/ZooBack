using System;
using System.Threading.Tasks;

namespace Zoo.Application.Events.Animals.Handlers
{
    internal class AnimalDeletedHandler : IEventHandler<AnimalDeleted>
    {
        public Task HandleAsync(AnimalDeleted @event)
        {
            Console.WriteLine($"Animal with id {@event.Id} has been deleted");
            return Task.CompletedTask;
        }
    }
}