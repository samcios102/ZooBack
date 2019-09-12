using System;
using Zoo.Core.Entities;
using Zoo.Core.Enums;

namespace Zoo.Application.Dto
{
    public class AnimalDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public HabitatType Habitat { get; set; }
        public Employee Keeper { get; set; }
        public Localisation Localisation { get; set; }
    }
}