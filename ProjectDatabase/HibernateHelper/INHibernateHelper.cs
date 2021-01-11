using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.HibernateHelper
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
    }
}
