using System;

namespace Zoo.Core.Entities
{
    public class Localisation
    {
        public Guid Id { get; }
        public int Section { get; }
        public int Cage { get; }

        public Localisation(Guid id, int section, int cage)
        {
            Id = id;
            Section = section;
            Cage = cage;
        }
        
    }
}