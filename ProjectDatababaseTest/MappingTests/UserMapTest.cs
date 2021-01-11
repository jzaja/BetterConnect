using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Xml.Serialization;
using NHibernate.Mapping.ByCode;
using ProjectDatabase.Domain;
using ProjectDatabase.Mappings;

namespace ProjectDatababaseTest.MappingTests
{
    [TestFixture]
    public class UserMapTest
    {
        [Test]
        public void CanGenerateXmlMapping()
        {
            //var mapper = new ModelMapper();
           // mapper.AddMapping<UserMap>();

            //var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            //var xmlSerializer = new XmlSerializer(mapping.GetType());

            //xmlSerializer.Serialize(Console.Out, mapping);
        }
    }
}
