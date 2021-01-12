using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.HibernateHelper
{

    public enum Environment
    {
        Test,
        Production
    }

    public class NHibernateHelperFactory
    {

        public static INHibernateHelper GetHelper(Environment environment)
        {
            if (environment == Environment.Test)
            {
                return new InMemoryNHibernateHelper();
            } else
            {
                return new NHibernateHelper();
            }
        }

    }
}
