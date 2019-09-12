using System;
using Zoo.Core.Enums;

namespace Zoo.Core.Entities
{
    public class Animal
    {
        public Guid Id { get; }
        public string Name { get; }
        
        public HabitatType Habitat { get; } 
        
        public Employee Keeper { get; }
        public Localisation Localisation { get; private set; }

        public Animal(Guid id, string name, Localisation localisation)
        {
            Id = id;
            Name = name;
            Localisation = localisation;
        }

        public void ChangeLocalisation(Localisation localisation)
        {
            Localisation = localisation;
        }
        
    }
}