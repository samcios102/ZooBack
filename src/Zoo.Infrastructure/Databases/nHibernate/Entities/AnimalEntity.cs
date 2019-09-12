using System;
using System.Collections.Generic;
using Zoo.Core.Entities;
using Zoo.Core.Enums;

namespace Zoo.Infrastructure.Databases.nHibernate.Entities
{
    internal class AnimalEntity : DbModel
    {

        public virtual string Name { get; set; }
        public virtual HabitatType Habitat { get; set; }
        public virtual Employee Keeper { get; set; }
        public virtual Localisation Localisation { get; set; }
        
    }
}