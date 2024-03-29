using System;
using System.Threading.Tasks;
using NHibernate;
using Zoo.Core.Entities;
using Zoo.Core.Repositories;
using Zoo.Infrastructure.Databases;
using Zoo.Infrastructure.Databases.nHibernate.Entities;
using Zoo.Infrastructure.Databases.nHibernate.Entities.Extensions;

namespace Zoo.Infrastructure.Repositories
{
    internal class AnimalRepository : IAnimalRepository
    {
        private readonly IRepository<AnimalEntity> _repository;

        public AnimalRepository(IRepository<AnimalEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Animal> GetAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            return entity?.AsAnimal();
        }

        public Task AddAsync(Animal animal)
            => _repository.AddAsync(animal.AsEntity());
        
        public Task UpdateAsync(Animal animal)
            => _repository.UpdateAsync(animal.AsEntity());

        public Task DeleteAsync(Animal animal)
        {
            return _repository.DeleteAsync(animal.AsEntity());
        }
    }
}