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
    public class UpdateAnimalHandlerTests
    {
        
        Task Act(UpdateAnimal command)
        {
            return _handler.HandleAsync(command);
        }

        [Fact]
        public async Task HandleAsync_Should_Update_Animal_With_Given_Id_Using_Repository()
        {
            var command = new UpdateAnimal(Guid.NewGuid(), HabitatType.Basic,null,null);

            var animal = new Animal(command.Id, "Name", HabitatType.Basic, null, null);
            
            _repository.GetAsync(command.Id).Returns(animal);
            
            await Act(command);
            
            await _repository.Received(1).UpdateAsync(animal);
            
        }
        
        #region ARRANGE

        private readonly ICommandHandler<UpdateAnimal> _handler;
        private readonly IAnimalRepository _repository;
        private readonly IMessageBroker _broker;

        public UpdateAnimalHandlerTests()
        {
            _repository = Substitute.For<IAnimalRepository>();
            _broker = Substitute.For<IMessageBroker>();
            _handler = new UpdateAnimalHandler(_repository, _broker);
        }

        #endregion
        
    }
}
