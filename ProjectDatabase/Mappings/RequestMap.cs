using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using ProjectDatabase.Domain;

namespace ProjectDatabase.Mappings
{
    public class RequestMap : ClassMap<Request>
    {
        public RequestMap()
        {
            CompositeId().KeyProperty(x => x.SenderId).KeyProperty(x => x.ReceiverId);
            Map(x => x.ConfirmationsNum);
        }
    }
}
