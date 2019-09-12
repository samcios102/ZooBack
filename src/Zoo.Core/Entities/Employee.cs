using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Core.Enums;

namespace Zoo.Core.Entities
{
    public class Employee
    {
        public Guid Id { get; }
        public string Name { get; }
        public IEnumerable<HabitatType> TypesOfHabitatsAbleToWorkWith { get; private set; }

        public Employee(Guid id, string name, IEnumerable<HabitatType> typesOfHabitatsAbleToWorkWith)
        {
            Id = Id;
            Name = name;
            TypesOfHabitatsAbleToWorkWith = typesOfHabitatsAbleToWorkWith;
        }

        public void AddNewHabitatToWorkWith(HabitatType habitatType)
        {
            var habitats = TypesOfHabitatsAbleToWorkWith.ToList();
            habitats.Add(habitatType);
            var habitatsEnumerable = (IEnumerable<HabitatType>) habitats;
            TypesOfHabitatsAbleToWorkWith = habitatsEnumerable;
        }
        
        public void RemoveExistingHabitatToWorkWith(HabitatType habitatType)
        {
            var habitats = TypesOfHabitatsAbleToWorkWith.ToList();
            habitats.Remove(habitatType);
            var habitatsEnumerable = (IEnumerable<HabitatType>) habitats;
            TypesOfHabitatsAbleToWorkWith = habitatsEnumerable;
        }
    }
}