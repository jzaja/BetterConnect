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
    public class RequestRepositoryTest
    {
        private IRequestRepository _requestRepository;

        [SetUp]
        public void Setup()
        {
            _requestRepository = new RequestRepository(NHibernateHelperFactory.GetHelper(Environment.Test));
        }

        [Test]
        public void TestSave()
        {
            var req = new Request { SenderId = 1, ReceiverId = 1, ConfirmationsNum = 1 };
            _requestRepository.Save(req);
            Assert.AreEqual(1, _requestRepository.RowCount());

            var req2 = new Request { SenderId = 10, ReceiverId = 11, ConfirmationsNum = 1 };
            _requestRepository.Save(req2);
            Assert.AreEqual(2, _requestRepository.RowCount());
        }

    }
}
