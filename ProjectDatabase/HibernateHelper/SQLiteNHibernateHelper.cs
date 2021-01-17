using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ProjectDatabase.Mappings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectDatabase.HibernateHelper
{
    public class SQLiteNHibernateHelper : INHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private ISession _session;

        public SQLiteNHibernateHelper()
        {
            OpenSessionFactory();
        }

        public ISession OpenSession()
        {
            try
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = OpenSessionFactory();
                }

                return _session;
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        private ISessionFactory OpenSessionFactory()
        {
            var nhConfig = Fluently.Configure()
                .Diagnostics(diag => diag.Enable().OutputToConsole())
                .Database(SQLiteConfiguration.Standard.UsingFile("database.db"))
                .Mappings(mappings => mappings.FluentMappings.Add<BasicUserMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<UserMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<AdminMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<InterestMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<RequestMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildConfiguration();

            var sessionFactory = nhConfig.BuildSessionFactory();
            _sessionFactory = sessionFactory;
            _session = sessionFactory.OpenSession();

            return sessionFactory;
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists("database.db"))
                File.Delete("database.db");

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaUpdate(config).Execute(true, true);
            //new SchemaExport(config).Create(false, true);
        }

    }
}
