using System;

namespace Zoo.Application.Commands.Animals
{
    public class DeleteAnimal : ICommand
    {
        public Guid Id { get; }

        public DeleteAnimal(Guid id)
        {
            Id = id;
        }
    }
}