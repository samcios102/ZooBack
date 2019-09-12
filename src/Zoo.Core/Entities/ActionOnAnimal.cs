using System;
using Zoo.Core.Enums;

namespace Zoo.Core.Entities
{
    public class ActionOnAnimal
    {
        public Guid Id { get; }
        public Employee Employee { get; }
        public Animal Animal { get; }
        public ActionType ActionType { get; }
        public DateTime DateAndTimeWhenActionOccurred { get; }


        public ActionOnAnimal(Guid id, Employee employee, Animal animal, ActionType actionType,
            DateTime dateAndTimeWhenActionOccurred)
        {
            Id = id;
            Employee = employee;
            Animal = animal;
            ActionType = actionType;
            DateAndTimeWhenActionOccurred = dateAndTimeWhenActionOccurred;
        }
    }
}