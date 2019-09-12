using System;
using System.Threading.Tasks;
using Zoo.Application.Commands.Animals;

namespace Zoo.Application.Events.Animals.Handlers
{
    internal class AnimalUpdatedHandler : IEventHandler<AnimalUpdated>
    {
        public Task HandleAsync(AnimalUpdated @event)
        {
            Console.WriteLine($"Animal with id{@event.Id} has been updated");
            return Task.CompletedTask;
        }
    }
}