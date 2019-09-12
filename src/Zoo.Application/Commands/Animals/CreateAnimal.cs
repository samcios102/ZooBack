using System;
using Zoo.Core.Entities;
using Zoo.Core.Enums;

namespace Zoo.Application.Commands.Animals
{
    public class CreateAnimal : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public HabitatType Habitat { get; }
        public Employee Keeper { get; }
        public Localisation Localisation { get; }

        public CreateAnimal(string name, HabitatType habitatType, Employee employee, Localisation localisation)
        {
            Id = Guid.NewGuid();
            Name = name;
            Habitat = habitatType;
            Keeper = employee;
            Localisation = localisation;
        }
    }
}