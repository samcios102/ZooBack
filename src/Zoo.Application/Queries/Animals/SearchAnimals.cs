using System;
using System.Collections.Generic;
using Zoo.Application.Dto;
using Zoo.Core.Entities;
using Zoo.Core.Enums;

namespace Zoo.Application.Queries.Animals
{
    public class SearchAnimals : IQuery<IEnumerable<AnimalDto>>
    {
        public string Name { get; set; }
        public HabitatType? Habitat { get; set; }
        public Employee Keeper { get; set; }
        public Localisation Localisation { get; set; }
    }
}