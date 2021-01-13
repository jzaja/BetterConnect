using Moq;
using NUnit.Framework;
using ProjectDatabase.Domain;
using ProjectDatabase.Repository;
using ProjectDatabase.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatababaseTest.ServiceTest
{
    [TestFixture]
    public class RequestServiceTest
    {
        private Mock<IRequestRepository> _mockRequestRepo;
        private Mock<IUserRepository> _mockUserRepo;

        [SetUp]
        public void Setup()
        {
            _mockRequestRepo = new Mock<IRequestRepository>();
            _mockUserRepo = new Mock<IUserRepository>();
        }

        [Test]
        public void TestSendRequest()
        {
            var sender = Generator.GenerateUser("sender", "pass", "091");
            var receiver = Generator.GenerateUser("receiver", "pass", "098");

            _mockRequestRepo.Setup(x => x.GetByKey(sender.Id, receiver.Id)).Returns((Request)null);
            _mockUserRepo.Setup(x => x.GetUser(sender.Id)).Returns(sender);
            _mockUserRepo.Setup(x => x.GetUser(receiver.Id)).Returns(receiver);
            _mockUserRepo.Setup(x => x.Save(sender)).Returns(sender);
            _mockUserRepo.Setup(x => x.Save(receiver)).Returns(receiver);

            var req = new Request { SenderId = sender.Id, ReceiverId = receiver.Id, IsConfirmed = false, IsDeclined = false };

            _mockRequestRepo.Setup(x => x.Save(req)).Returns(req);

            var service = new RequestService(_mockRequestRepo.Object, _mockUserRepo.Object);
            var savedRequest = service.SendRequest(sender.Id, receiver.Id);

            Assert.NotNull(savedRequest);
        }

        [Test]
        public void TestSendingAlreadySentRequest()
        {
            var sender = Generator.GenerateUser("sender", "pass", "091");
            var receiver = Generator.GenerateUser("receiver", "pass", "098");
            var req = new Request { SenderId = sender.Id, ReceiverId = receiver.Id, IsConfirmed = false, IsDeclined = false };

            _mockRequestRepo.Setup(x => x.GetByKey(sender.Id, receiver.Id)).Returns(req);
            
            var service = new RequestService(_mockRequestRepo.Object, _mockUserRepo.Object);
            var savedRequest = service.SendRequest(sender.Id, receiver.Id);

            Assert.Null(savedRequest);
        }

        [Test]
        public void TestApproveRequest()
        {
            var sender = Generator.GenerateUser("sender", "pass", "091");
            var receiver = Generator.GenerateUser("receiver", "pass", "098");
            var req = new Request { SenderId = sender.Id, ReceiverId = receiver.Id, IsConfirmed = false, IsDeclined = false };

            _mockRequestRepo.Setup(x => x.GetByKey(sender.Id, receiver.Id)).Returns(req);
            _mockUserRepo.Setup(x => x.GetUser(sender.Id)).Returns(sender);
            _mockUserRepo.Setup(x => x.GetUser(receiver.Id)).Returns(receiver);
            _mockRequestRepo.Setup(x => x.Update(req)).Returns(req);

            var service = new RequestService(_mockRequestRepo.Object, _mockUserRepo.Object);
            var approved = service.UpdateRequest(sender.Id, receiver.Id, true, false);
            Assert.IsTrue(approved.IsConfirmed);
            Assert.IsFalse(approved.IsDeclined);
        }

        [Test]
        public void TestDeclineRequest()
        {
            var sender = Generator.GenerateUser("sender", "pass", "091");
            var receiver = Generator.GenerateUser("receiver", "pass", "098");
            var req = new Request { SenderId = sender.Id, ReceiverId = receiver.Id, IsConfirmed = false, IsDeclined = false };

            _mockRequestRepo.Setup(x => x.GetByKey(sender.Id, receiver.Id)).Returns(req);
            _mockUserRepo.Setup(x => x.GetUser(sender.Id)).Returns(sender);
            _mockUserRepo.Setup(x => x.GetUser(receiver.Id)).Returns(receiver);
            _mockRequestRepo.Setup(x => x.Update(req)).Returns(req);

            var service = new RequestService(_mockRequestRepo.Object, _mockUserRepo.Object);
            var approved = service.UpdateRequest(sender.Id, receiver.Id, false, true);
            Assert.IsFalse(approved.IsConfirmed);
            Assert.IsTrue(approved.IsDeclined);
        }

    }
}
