using System.Reflection;
using Core;
using Data.NHibernateMappings;
using Domain.Dtos;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Caches.SysCache;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;


namespace Data
{
    public static class NHibernateInitializer
    {
        public static ISessionFactory GetSessionFactory(string configurationName = "command")
        {
            var commandConfiguration = BuildDatabaseConfiguration(configurationName);

            return commandConfiguration.BuildSessionFactory();
        }

        public static Configuration BuildDatabaseConfiguration(string name)
        {
            var configuration = new Configuration();

            configuration.Proxy(p => p.ProxyFactoryFactory<StaticProxyFactoryFactory>())
                         .DataBaseIntegration(db =>
                         {
                             db.ConnectionString = DbConnectionFactory.ConnectionString;
                             db.Dialect<MsSql2008Dialect>();
                             db.Driver<Sql2008ClientDriver>();
                         })
                         .AddAssembly(typeof(ResourceDto).Assembly);

            configuration.SessionFactory()
                .Named(name)
                .Caching.Through<SysCacheProvider>()
                .WithDefaultExpiration(1440);

            var compiledMapping = GetModelMapper().CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddMapping(compiledMapping);

            return configuration;
        }

        public static ModelMapper GetModelMapper()
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(ResourceMap).Assembly.GetExportedTypes());
            mapper.BeforeMapProperty += MapperOnBeforeMapProperty;

            return mapper;
        }

        private static void MapperOnBeforeMapProperty(IModelInspector modelinspector, PropertyPath member, IPropertyMapper propertycustomizer)
        {
            var info = (PropertyInfo)member.LocalMember;

            if (info.PropertyType == typeof(string))
            {
                propertycustomizer.Type(NHibernateUtil.AnsiString);
            }
        }
    }
}

