using System.Threading.Tasks;
using Zoo.Application.Events.Animals;
using Zoo.Application.Services;
using Zoo.Core.Repositories;

namespace Zoo.Application.Commands.Animals.Handlers
{
    public class DeleteAnimalHandler : ICommandHandler<DeleteAnimal>
    {
        private readonly IAnimalRepository _repository;
        private readonly IMessageBroker _broker;

        public DeleteAnimalHandler(IAnimalRepository repository, IMessageBroker broker)
        {
            _repository = repository;
            _broker = broker;
        }

        public async Task HandleAsync(DeleteAnimal command)
        {
            var animalToDelete = await _repository.GetAsync(command.Id);
            await _repository.DeleteAsync(animalToDelete);
            await _broker.PublishAsync(new AnimalDeleted(command.Id));

        }
    }
}