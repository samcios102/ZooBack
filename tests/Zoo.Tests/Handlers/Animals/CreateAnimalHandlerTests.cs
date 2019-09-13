using System;
using System.Collections.Generic;
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
    public class CreateAnimalHandlerTests
    {
        Task Act(CreateAnimal command)
        {
            return _handler.HandleAsync(command);
        }

        [Fact]
        public async Task HandleAsync_Should_Create_Animal_With_Given_Id_And_Name_Using_Repository()
        {
            var command = new CreateAnimal("NameOfAnimal", HabitatType.Basic, 
                new Employee(Guid.NewGuid(),"NameOfEmployee", new List<HabitatType>()),
                new Localisation(Guid.NewGuid(), 0,0 ));

            await Act(command);
            
            await _repository
                .Received(1)
                .AddAsync(Arg.Is<Animal>( animal => 
                    animal.Id == command.Id &&
                    animal.Name == command.Name));
        }
        

        #region ARRANGE

        private readonly ICommandHandler<CreateAnimal> _handler;
        private readonly IAnimalRepository _repository;
        private readonly IMessageBroker _broker;

        public CreateAnimalHandlerTests()
        {
            _repository = Substitute.For<IAnimalRepository>();
            _broker = Substitute.For<IMessageBroker>();
            _handler = new CreateAnimalHandler(_repository, _broker);
        }
        
        #endregion
    }
}