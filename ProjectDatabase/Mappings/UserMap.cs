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
            Map(x => x.PhoneNumber).Not.Nullable();
            Map(x => x.ImageUrl);
            HasManyToMany(x => x.Interests)
                .Cascade.All()
                .Inverse()
                .Table("UserInterest");
            HasMany(x => x.Requests);
        }

    }
    
}
