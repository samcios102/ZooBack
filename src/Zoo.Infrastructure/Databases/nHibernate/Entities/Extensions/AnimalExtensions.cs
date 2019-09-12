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
        
    }
}