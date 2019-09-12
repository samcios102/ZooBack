using System;
using System.Threading.Tasks;
using Zoo.Core.Entities;

namespace Zoo.Core.Repositories
{
    public interface IAnimalRepository
    {
        Task<Animal> GetAsync(Guid id);
        Task AddAsync(Animal animal);
        Task UpdateAsync(Animal animal);
        Task DeleteAsync(Animal animal);
    }
}