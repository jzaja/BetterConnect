using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ProjectDatabase.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.HibernateHelper
{
    public class InMemoryNHibernateHelper : INHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private ISession _session;
        Configuration config;

        public InMemoryNHibernateHelper()
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
                .Database(SQLiteConfiguration.Standard.InMemory())
                .Mappings(mappings => mappings.FluentMappings.Add<BasicUserMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<UserMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<AdminMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<InterestMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<RequestMap>())
                .ExposeConfiguration(cfg => config = cfg)
                .BuildConfiguration();

            var sessionFactory = nhConfig.BuildSessionFactory();
            _sessionFactory = sessionFactory;
            _session = sessionFactory.OpenSession();

            new SchemaExport(config).Execute(true, true, false, _session.Connection, null);

            return sessionFactory;
        }
    }
}
