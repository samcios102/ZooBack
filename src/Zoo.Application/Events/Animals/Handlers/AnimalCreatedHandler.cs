using System;
using System.Threading.Tasks;

namespace Zoo.Application.Events.Animals.Handlers
{
    internal class AnimalCreatedHandler : IEventHandler<AnimalCreated>
    {
        public Task HandleAsync(AnimalCreated @event)
        {
            Console.WriteLine($"Animal with id {@event.Id} has been created");
            return Task.CompletedTask;
        }
    }
}