using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using ProjectDatabase.Domain;

namespace ProjectDatabase.Mappings
{
    public class BasicUserMap : ClassMap<BasicUser>
    {
        public BasicUserMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Username).Not.Nullable().Unique();
            Map(x => x.Password).Not.Nullable();
        }
    }
}
