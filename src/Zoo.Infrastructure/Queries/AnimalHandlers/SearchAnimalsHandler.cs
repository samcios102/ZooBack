using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Application.Dto;
using Zoo.Application.Queries;
using Zoo.Application.Queries.Animals;
using Zoo.Infrastructure.Databases;
using Zoo.Infrastructure.Databases.nHibernate.Entities;
using Zoo.Infrastructure.Databases.nHibernate.Entities.Extensions;

namespace Zoo.Infrastructure.Queries.AnimalHandlers
{
    internal class SearchAnimalsHandler : IQueryHandler<SearchAnimals, IEnumerable<AnimalDto>>
    {
        private readonly IRepository<AnimalEntity> _repository;

        public SearchAnimalsHandler(IRepository<AnimalEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AnimalDto>> HandleAsync(SearchAnimals query)
        {
            var entities = await _repository
                .SearchAsync(animal =>
                    animal.Name.ToLower().Contains(query.Name.ToLower())); 

            entities = entities
                .Where(animal => 
                    !query.Habitat.HasValue || 
                    animal.Habitat == query.Habitat
                    );

            entities = entities
                .Where(animal =>
                    (query.Keeper is null) ||
                    query.Keeper.Id == animal.Keeper.Id
                    );
            
            entities = entities
                .Where(animal =>
                    (query.Localisation is null) ||
                    query.Localisation.Id == animal.Localisation.Id
                    );

            return entities.AsEnumerableDto();
        }
    }
}