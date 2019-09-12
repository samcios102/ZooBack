using System;
using Zoo.Core.Entities;

namespace Zoo.Application.Events.Animals
{
    public class AnimalUpdated : IEvent
    {
        public Guid Id { get; }

        public AnimalUpdated(Guid id)
        {
            Id = id;
        }
    }
}