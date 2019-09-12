using System;

namespace Zoo.Application.Events.Animals
{
    public class AnimalCreated : IEvent
    {
        public Guid Id { get; }

        public AnimalCreated(Guid id)
        {
            Id = id;
        }
    }
}