using System.Threading.Tasks;
using Zoo.Application.Events.Animals;
using Zoo.Application.Services;
using Zoo.Core.Entities;
using Zoo.Core.Repositories;

namespace Zoo.Application.Commands.Animals.Handlers
{
    public class UpdateAnimalHandler : ICommandHandler<UpdateAnimal>
    {
        private readonly IAnimalRepository _repository;
        private readonly IMessageBroker _broker;

        public UpdateAnimalHandler(IAnimalRepository repository, IMessageBroker broker)
        {
            _repository = repository;
            _broker = broker;
        }

        public async Task HandleAsync(UpdateAnimal command)
        {
            var oldAnimal = await _repository.GetAsync(command.Id);
            
            var updatedAnimal = new Animal(
                oldAnimal.Id, 
                oldAnimal.Name, 
                command.Habitat,
                command.Keeper, 
                command.Localisation);

            await _repository.UpdateAsync(updatedAnimal);
            await _broker.PublishAsync(new AnimalUpdated(command.Id));
        }
    }
}