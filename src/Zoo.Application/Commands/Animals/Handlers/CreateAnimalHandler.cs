using System.Threading.Tasks;
using Zoo.Application.Events.Animals;
using Zoo.Application.Services;
using Zoo.Core.Entities;
using Zoo.Core.Repositories;

namespace Zoo.Application.Commands.Animals.Handlers
{
    public class CreateAnimalHandler : ICommandHandler<CreateAnimal>
    {
        private readonly IAnimalRepository _repository;
        private readonly IMessageBroker _broker;

        public CreateAnimalHandler(IAnimalRepository repository, IMessageBroker broker)
        {
            _repository = repository;
            _broker = broker;
        }

        public async Task HandleAsync(CreateAnimal command)
        {
            var newAnimal = new Animal(command.Id, command.Name, command.Habitat, command.Keeper, command.Localisation);
            await _repository.AddAsync(newAnimal);
            await _broker.PublishAsync(new AnimalCreated(command.Id));
        }
        
        
    }
}