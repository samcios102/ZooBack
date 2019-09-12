using System.Collections.Generic;
using System.Linq;
using Zoo.Application.Dto;
using Zoo.Core.Entities;
using Zoo.Infrastructure.Databases.nHibernate.Entities.Mappings;

namespace Zoo.Infrastructure.Databases.nHibernate.Entities.Extensions
{
    internal static class AnimalExtensions
    {
        public static Animal AsAnimal(this AnimalEntity animalEntity)
            => new Animal(animalEntity.Id, animalEntity.Name,animalEntity.Habitat,animalEntity.Keeper,animalEntity.Localisation);

        public static AnimalEntity AsEntity(this Animal animal)
            => new AnimalEntity
            {
                Id = animal.Id,
                Name = animal.Name,
                Habitat = animal.Habitat,
                Keeper = animal.Keeper,
                Localisation = animal.Localisation
            };

        public static IEnumerable<AnimalDto> AsEnumerableDto(this IEnumerable<Animal> animals)
            => animals.Select(animal => new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Habitat = animal.Habitat,
                Keeper = animal.Keeper,
                Localisation = animal.Localisation
            });
        
        public static AnimalDto AsDto (this Animal animal) 
            => new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Habitat = animal.Habitat,
                Keeper = animal.Keeper,
                Localisation = animal.Localisation
            };
    }
}