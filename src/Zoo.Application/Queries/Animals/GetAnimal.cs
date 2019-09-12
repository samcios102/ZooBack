using System;
using Zoo.Application.Dto;

namespace Zoo.Application.Queries.Animals
{
    public class GetAnimal : IQuery<AnimalDto>
    {
        public Guid Id { get; }
        
    }
}