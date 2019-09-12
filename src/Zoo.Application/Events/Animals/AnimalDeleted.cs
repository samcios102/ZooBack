using System;

namespace Zoo.Application.Events.Animals
{
    public class AnimalDeleted : IEvent
    {
        public Guid Id { get; }

        public AnimalDeleted(Guid id)
        {
            Id = id;
        } 
    }
}