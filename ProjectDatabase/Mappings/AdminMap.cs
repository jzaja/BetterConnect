using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using ProjectDatabase.Domain;

namespace ProjectDatabase.Mappings
{
    public class AdminMap : SubclassMap<Admin>
    {
        public AdminMap()
        {
            Map(x => x.AdminRole).Not.Nullable();
        }
    }
}
