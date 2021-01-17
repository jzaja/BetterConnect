using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Tool.hbm2ddl;
using ProjectDatabase.Domain;
using ProjectDatabase.HibernateHelper;
using ProjectDatabase.Repository;
using ProjectDatabase.Repository.ConcreteRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Environment = ProjectDatabase.HibernateHelper.Environment;

namespace ProjectDatababaseTest.RepositoryTest
{
    [TestFixture]
    public class InterestRepositoryTest
    {
        private IInterestRepository _interestRepo;

        [SetUp]
        public void Setup()
        {
            _interestRepo = new InterestRepository(NHibernateHelperFactory.GetHelper(Environment.Test));
        }

        [Test]
        public void TestGetByName()
        {
            var interest = new Interest { Name = "Skijanje" };
            _interestRepo.Save(interest);

            Assert.NotNull(_interestRepo.GetByName("skijanje"));
            Assert.NotNull(_interestRepo.GetByName("Skijanje"));
            Assert.NotNull(_interestRepo.GetByName("SkIjAnjE"));
            Assert.Null(_interestRepo.GetByName("nepostojece"));
        }

        [Test]
        public void TestGetUsersByInterestName()
        {
            var interest = new Interest { Name = "skijanje" };
            var user = new User { Username = "misko", Password = "pass", PhoneNumber = "098" };
            user.AddInterest(interest);
            _interestRepo.Save(interest);

            var interestUsers = _interestRepo.GetUsersByInterestName(interest.Name);
            Assert.IsTrue(interestUsers.Count == 1);

            var user2 = new User { Username = "mali", Password = "pass", PhoneNumber = "099" };
            user2.AddInterest(interest);
            _interestRepo.Save(interest);

            interestUsers = _interestRepo.GetUsersByInterestName(interest.Name);
            Assert.IsTrue(interestUsers.Count == 2);
        }

    }
}
