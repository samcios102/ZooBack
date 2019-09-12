using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using Zoo.Core.Entities;
using Zoo.Core.Enums;

namespace Zoo.Infrastructure.Databases.nHibernate.Entities.Mappings
{
    internal class AnimalEntityMappings : ClassMapping<AnimalEntity>
    {
        public AnimalEntityMappings()
        {
            Id(x => x.Id);
            Property(x => x.Name, map => map.NotNullable(true));
            Property(x => x.Habitat, map => map.Type<EnumStringType<HabitatType>>());
            Property(x => x.Keeper, map => map.Type<Employee>());
            Property(x => x.Localisation, map => map.Type<Localisation>());
        }
    }
}