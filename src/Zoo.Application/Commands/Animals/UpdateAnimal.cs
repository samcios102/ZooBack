using System;
using Zoo.Core.Entities;
using Zoo.Core.Enums;

namespace Zoo.Application.Commands.Animals
{
    public class UpdateAnimal : ICommand
    {
        public Guid Id { get; }
        public HabitatType Habitat { get; }
        public Employee Keeper { get; }
        public Localisation Localisation { get; }

        public UpdateAnimal(Guid id, HabitatType habitat, Employee keeper, Localisation localisation)
        {
            Id = id;
            Habitat = habitat;
            Keeper = keeper;
            Localisation = localisation;
        }
    }
}