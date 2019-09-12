using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Application.Dto;
using Zoo.Application.Events;
using Zoo.Application.Queries;
using Zoo.Application.Queries.Animals;
using Zoo.Infrastructure.Queries.AnimalHandlers;

namespace Zoo.Infrastructure.Queries
{
    internal static class Extensions
    {
        public static void AddQueryHandlers(this IServiceCollection services)
        {
           services.AddTransient<IQueryHandler<GetAnimal, AnimalDto>, GetAnimalHandler>();
           services.AddTransient<IQueryHandler<SearchAnimals, IEnumerable<AnimalDto>>, SearchAnimalsHandler>();
           
        }
        
    }
}