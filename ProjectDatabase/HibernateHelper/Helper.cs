using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using ProjectDatabase.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.HibernateHelper
{
    public class Helper
    {
        public static ISessionFactory _sessionFactory;

        private static void CreateSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString("connstring").ShowSql)
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BasicUser>())
               .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
            .BuildSessionFactory();
        }

    }
}
