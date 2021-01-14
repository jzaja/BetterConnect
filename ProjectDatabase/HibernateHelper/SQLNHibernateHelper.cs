using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ProjectDatabase.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.HibernateHelper
{
    public class SQLNHibernateHelper : INHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private ISession _session;
        Configuration config;

        public SQLNHibernateHelper()
        {
            CreateSessionFactory();
        }

        public ISession OpenSession()
        {
            throw new NotImplementedException();
        }

        private void CreateSessionFactory()
        {
            var connectionString = "connstring";

            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).ShowSql)
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Admin>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BasicUser>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Interest>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Request>())
               .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
            .BuildSessionFactory();
        }

    }
}
