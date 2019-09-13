using System;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using Zoo.Application.Commands;
using Zoo.Application.Commands.Animals;
using Zoo.Application.Commands.Animals.Handlers;
using Zoo.Application.Services;
using Zoo.Core.Entities;
using Zoo.Core.Enums;
using Zoo.Core.Repositories;

namespace Zoo.Tests.Handlers.Animals
{
    public class DeleteAnimalHandlerTests
    {

        Task Act(DeleteAnimal command)
        {
           return _handler.HandleAsync(command);
        }

        [Fact]
        public async Task HandleAsync_Should_Delete_Animal_With_Given_Id_From_Repository()
        {
            var command = new DeleteAnimal(Guid.NewGuid());
            var animal = new Animal(command.Id, "Name", HabitatType.Basic, null, null);

            _repository.GetAsync(command.Id).Returns(animal);

            await Act(command);

            await _repository.Received(1).DeleteAsync(animal);

        }
        
        
        #region ARRANGE

        private readonly ICommandHandler<DeleteAnimal> _handler;
        private readonly IAnimalRepository _repository;
        private readonly IMessageBroker _broker;

        public DeleteAnimalHandlerTests()
        {
            _repository = Substitute.For<IAnimalRepository>();
            _broker = Substitute.For<IMessageBroker>();
            _handler = new DeleteAnimalHandler(_repository, _broker);
        }
        
        #endregion
    }
}