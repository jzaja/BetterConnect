using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using ProjectDatabase.Domain;
using ProjectDatabase.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.HibernateHelper
{
    public class NHibernateHelper : INHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;
        private static NHibernate.Cfg.MappingSchema.HbmMapping _mapping;

        //public static ISession OpenSession()
       // {
            //Open and return the nhibernate session
           // return SessionFactory.OpenSession();
        //}

        public ISession OpenSession()
        {
            try
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = OpenSessionFactory();
                }

                ISession session = _sessionFactory.OpenSession();
                // new SchemaExport(_configuration).Execute(true, true, false, session.Connection, null);
                new SchemaExport(_configuration).Create(true, true);
                return session;
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        private static ISessionFactory OpenSessionFactory()
        {

            return MyConfig.BuildSessionFactory();
            //return cfg.BuildSessionFactory();
        }

        public static Configuration MyConfig
        {
            get
            {
                if (_configuration == null)
                {
                    var cfg = new Configuration();
                    cfg.Configure();
                    Fluently.Configure(cfg)
                    .Database(SQLiteConfiguration.Standard.InMemory())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Interest>())
                    .ExposeConfiguration(c =>
                    {
                        _configuration = c; //pass configuration to class scoped variable
                        //new SchemaExport(c).Create(true, true);
                    })
                    .BuildConfiguration();

                    _configuration = cfg;
                }

                return _configuration;
            }
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    //Create the session factory
                    _sessionFactory = Configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    //Create the nhibernate configuration
                    _configuration = CreateConfiguration();
                }
                return _configuration;
            }
        }

        public static HbmMapping Mapping
        {
            get
            {
                if (_mapping == null)
                {
                    //Create the mapping
                    _mapping = CreateMapping();
                }
                return _mapping;
            }
        }

        private static Configuration CreateConfiguration()
        {
            var configuration = new Configuration();
            //Loads properties from hibernate.cfg.xml
            configuration.Configure();
            //Loads nhibernate mappings 
            configuration.AddDeserializedMapping(Mapping, null);

            return configuration;
        }

        private static HbmMapping CreateMapping()
        {
            var mapper = new ModelMapper();

            //Add mappings
            mapper.AddMappings(new List<System.Type> { typeof(UserMap) });
            mapper.AddMappings(new List<System.Type> { typeof(InterestMap) });

            //Create and return a HbmMapping of the model mapping in code
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}
