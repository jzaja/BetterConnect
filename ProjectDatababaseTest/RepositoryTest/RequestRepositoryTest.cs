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
            var req = new Request { SenderId = 1, ReceiverId = 2 };
            _requestRepository.Save(req);
            Assert.AreEqual(1, _requestRepository.RowCount());

            var req2 = new Request { SenderId = 10, ReceiverId = 11 };
            _requestRepository.Save(req2);
            Assert.AreEqual(2, _requestRepository.RowCount());
        }

        [Test]
        public void TestUpdate()
        {
            var req = new Request { SenderId = 1, ReceiverId = 2 };
            _requestRepository.Save(req);
            Assert.AreEqual(1, _requestRepository.RowCount());

            var existingReq = _requestRepository.GetByKey(1, 2);
            existingReq.IsConfirmed = true;
            var updated = _requestRepository.Update(existingReq);
            Assert.IsTrue(updated.IsConfirmed);
        }

        [Test]
        public void TestCount()
        {
            var req = new Request { SenderId = 1, ReceiverId = 2 };
            _requestRepository.Save(req);
            var req2 = new Request { SenderId = 10, ReceiverId = 11 };
            _requestRepository.Save(req2);

            Assert.AreEqual(2, _requestRepository.RowCount());
        }

        [Test]
        public void TestGetByKey()
        {
            var req = new Request { SenderId = 1, ReceiverId = 2 };
            _requestRepository.Save(req);

            Assert.NotNull(_requestRepository.GetByKey(req.SenderId, req.ReceiverId));

            Assert.Null(_requestRepository.GetByKey(req.SenderId, 544));

            Assert.Null(_requestRepository.GetByKey(544, req.ReceiverId));

            Assert.Null(_requestRepository.GetByKey(544, 544));
        }

    }
}
