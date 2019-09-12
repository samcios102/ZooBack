using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public CreateAnimal(string name,HabitatType habitat, Employee keeper, Localisation localisation)
        {
            Id = Guid.NewGuid();
            Name = name;
            Habitat = habitat;
            Keeper = keeper ?? new Employee(Guid.NewGuid(), "Basic", new List<HabitatType>());
            Localisation = localisation ?? new Localisation(Guid.NewGuid(), 0 ,0);
        }
    }
}