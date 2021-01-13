using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ProjectDatabase.Domain;

namespace ProjectDatabase.Mappings
{
    public class UserMap: SubclassMap<User>
    {

        public UserMap()
        {
            //Table("User");
            //Id(x => x.Id).GeneratedBy.Identity().Column("Id");
           // Map(x => x.Username).Not.Nullable().Unique();
            //Map(x => x.Password).Not.Nullable();
            Map(x => x.PhoneNumber).Not.Nullable();
            HasManyToMany(x => x.Interests)
                .Cascade.All()
                .Table("UserInterest");
            HasMany(x => x.Requests);
        }

    }
    
    
}
