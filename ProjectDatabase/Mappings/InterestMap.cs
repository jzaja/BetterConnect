using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ProjectDatabase.Domain;

namespace ProjectDatabase.Mappings
{
    public class InterestMap : ClassMap<Interest>
    {
        public InterestMap()
        {
            Table("Interest");
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Name).Not.Nullable().Unique();
            HasManyToMany(x => x.Users)
                .Cascade.All()
                .Inverse()
                .Table("UserInterest");
        }
    }
}
