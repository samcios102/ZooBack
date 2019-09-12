using System.Threading.Tasks;
using Zoo.Application.Dto;
using Zoo.Application.Queries;
using Zoo.Application.Queries.Animals;
using Zoo.Infrastructure.Databases;
using Zoo.Infrastructure.Databases.nHibernate.Entities;
using Zoo.Infrastructure.Databases.nHibernate.Entities.Extensions;

namespace Zoo.Infrastructure.Queries.AnimalHandlers
{
    internal class GetAnimalHandler : IQueryHandler<GetAnimal, AnimalDto>
    {
        private readonly IRepository<AnimalEntity> _repository;

        public GetAnimalHandler(IRepository<AnimalEntity> repository)
        {
            _repository = repository;
        }

        public async Task<AnimalDto> HandleAsync(GetAnimal query)
        {
            var animal = await _repository.GetAsync(query.Id);
            return animal?.AsDto();
        }
    }
}