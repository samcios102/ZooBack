using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using Zoo.Infrastructure.Databases.nHibernate.Entities.Mappings;
using Zoo.Infrastructure.Options;

namespace Zoo.Infrastructure.Databases.nHibernate
{
    internal sealed class AppSessionFactory
    {
        private readonly ISessionFactory _sessionFactory;

        public AppSessionFactory(DatabaseOptions options)
        {
            var mapper = new ModelMapper();
            mapper.AddMapping<AnimalEntityMappings>();
            var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var configuration = new Configuration();
            configuration.SessionFactoryName(options.InstanceName);
            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionString = options.ConnectionString;
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
                db.LogFormattedSql = true;
                db.LogFormattedSql = true;
                db.AutoCommentSql = true;
            })
                .AddMapping(domainMapping);

            configuration.SessionFactory().GenerateStatistics();
            _sessionFactory = configuration.BuildSessionFactory();
            
            new SchemaUpdate(configuration).Execute(false,true);
        }

        public ISession OpenSession()
            => _sessionFactory.OpenSession();

    }
}